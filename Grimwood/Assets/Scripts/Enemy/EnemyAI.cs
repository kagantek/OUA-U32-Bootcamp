using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    float lastAttackTime = 0;
    float attackCooldown = 2;
    [SerializeField] float stoppingDistance;
    [SerializeField] float detectionRadius = 10f; // Görüþ mesafesi
    [SerializeField] float attackDistance = 2f;   // Saldýrý mesafesi
    [SerializeField] float returnToStartDelay = 3f; // Baþlangýç noktasýna dönme gecikmesi

    NavMeshAgent agent;
    Animator anim;
    GameObject target;
    Vector3 startPosition; // Baþlangýç pozisyonu

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player");
        startPosition = transform.position; // Baþlangýç pozisyonunu kaydet
    }

    private void Update()
    {
        float dist = Vector3.Distance(transform.position, target.transform.position);
        if (dist < attackDistance)
        {
            StopEnemy();
            Attack();
        }
        else if (dist < stoppingDistance) // Durdurma mesafesinde ise dur
        {
            StopEnemy();
        }
        else if (dist <= detectionRadius) // Görüþ mesafesinde ise hedefe git
        {
            GoToTarget();
        }
        else // Görüþ mesafesinin dýþýndaysa baþlangýç noktasýna dön
        {
            ReturnToStart();
        }
    }

    private void GoToTarget()
    {
        agent.isStopped = false;
        agent.SetDestination(target.transform.position);
        anim.SetBool("isWalking", true);
        anim.SetBool("Attack", false);
    }

    private void StopEnemy()
    {
        agent.isStopped = true;
        anim.SetBool("isWalking", false);
    }

    private void ReturnToStart()
    {
        agent.isStopped = false;
        agent.SetDestination(startPosition);
        anim.SetBool("isWalking", true);
        anim.SetBool("Attack", false);

        // Eðer baþlangýç pozisyonuna döndüyse idle duruma geç
        if (Vector3.Distance(transform.position, startPosition) < 0.1f)
        {
            Idle();
        }
    }

    private void Idle()
    {
        agent.isStopped = true;
        anim.SetBool("isWalking", false);
        anim.SetBool("Attack", false);
    }

    private void Attack()
    {
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            lastAttackTime = Time.time;
            anim.SetBool("Attack", true);
        }
    }
}

