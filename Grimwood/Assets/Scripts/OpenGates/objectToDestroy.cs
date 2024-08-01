using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectToDestroy : MonoBehaviour
{
    public GameObject targetToDestroy;

    private bool isInTrigger = false;

    void Update()
    {        
        if (isInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            if (targetToDestroy != null)
            {
                Destroy(targetToDestroy);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {        
        if (other.CompareTag("Player"))
        {
            isInTrigger = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Eğer trigger alanından bir şey çıktığında
        if (other.CompareTag("Player")) // Burada "Player" tag'ini kontrol edebilirsiniz
        {
            isInTrigger = false; // Trigger alanından çıktık
        }
    }
}
