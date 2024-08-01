using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemMovement : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;
    private bool movingToB = true;
    private bool isIdle = false; // Idle durumunu kontrol etmek için bir değişken
    private bool isInRange = false; // Karakterin collider içinde olup olmadığını kontrol etmek için bir değişken
    private Animator animator; // Animator bileşenini saklamak için bir değişken

    void Start()
    {
        animator = GetComponent<Animator>(); // Animator bileşenini alıyoruz
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInRange) // E tuşuna basıldığında ve karakter collider içinde ise
        {
            isIdle = !isIdle; // Idle durumunu değiştiriyoruz
            animator.SetBool("IsIdle", isIdle); // Animator'daki "IsIdle" parametresini güncelliyoruz
        }

        if (!isIdle)
        {
            if (movingToB)
            {
                MoveToTarget(pointB.position);
            }
            else
            {
                MoveToTarget(pointA.position);
            }
        }
    }

    void MoveToTarget(Vector3 target)
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);

        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            movingToB = !movingToB;
            transform.Rotate(0f, 180f, 0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Eğer collider içindeki obje "Player" tag'ine sahipse
        {
            isInRange = true; // Karakterin collider içinde olduğunu işaretle
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Eğer collider içindeki obje "Player" tag'ine sahipse
        {
            isInRange = false; // Karakterin collider dışına çıktığını işaretle
            isIdle = !isIdle; // Idle durumunu değiştiriyoruz
            animator.SetBool("IsIdle", isIdle);
        }
    }
}
