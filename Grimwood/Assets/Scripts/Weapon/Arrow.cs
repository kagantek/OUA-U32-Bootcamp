using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Rigidbody rb;
    BoxCollider bx;
    bool disableRotation;
    public float destroyTime = 10f;
    public int damageAmount = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        bx = GetComponent<BoxCollider>();
        
        Destroy(this.gameObject, destroyTime);
    }

    private void Update()
    {
        if(!disableRotation)    
            transform.rotation = Quaternion.LookRotation(rb.velocity);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Player")
        {
            disableRotation = true;
            rb.isKinematic = true;
            bx.isTrigger = true;
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Skeleton")
        {
            //Destroy(transform.GetComponent<Rigidbody>());
            other.GetComponent<SkeletonDamage>().TakeDamage(damageAmount);
        }
        else if (other.tag == "Demon")
        {
            //Destroy(transform.GetComponent<Rigidbody>());
            other.GetComponent<DemonDamage>().TakeDamage(damageAmount);
        }
    }

}