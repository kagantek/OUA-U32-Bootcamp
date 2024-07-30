using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecreaseHealth : MonoBehaviour
{
    [SerializeField] private Healthbar healthbar;    
    private Coroutine damageCoroutine;

    void OnTriggerEnter(Collider other)
    {        
        if (other.CompareTag("Spike") || other.CompareTag("Skeleton") || other.CompareTag("Demon"))
        {            
            if (damageCoroutine == null)
            {
                damageCoroutine = StartCoroutine(DecreaseHealthOverTime());
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Spike") || other.CompareTag("Skeleton") || other.CompareTag("Demon"))
        {
            if (damageCoroutine != null)
            {
                StopCoroutine(damageCoroutine);
                damageCoroutine = null;
            }
        }
    }

    private IEnumerator DecreaseHealthOverTime()
    {
        while (true)
        {
            healthbar.UpdateHealth(-10);
            yield return new WaitForSeconds(2f);
        }
    }
}
