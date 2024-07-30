using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonDamage : MonoBehaviour
{
    public int hp = 2;
    Animator animator;
    int destroyTime = 2;

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
