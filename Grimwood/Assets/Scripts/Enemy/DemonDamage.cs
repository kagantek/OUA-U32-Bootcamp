using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonDamage : MonoBehaviour
{
    public int hp = 3;
    Animator animator;
    float destroyTime = 3.5f;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damageAmount)
    {
        hp -= damageAmount;
        if (hp <= 0)
        {
            animator.SetTrigger("die");
            Destroy(gameObject, destroyTime);
        }
    }
}
