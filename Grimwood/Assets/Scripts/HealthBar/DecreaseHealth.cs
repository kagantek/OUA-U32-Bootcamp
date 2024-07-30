using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecreaseHealth : MonoBehaviour
{
    [SerializeField] private Healthbar healthbar; // Healthbar referansı
    private Coroutine damageCoroutine; // Coroutine referansı
    private bool isInTrigger = false; // Nesnenin zararlı alanda olup olmadığını takip eden bayrak
    private List<GameObject> damagingObjects = new List<GameObject>(); // Zararlı objeleri takip eden liste

    // Zararlı bir objeye temas edildiğinde çalışır
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Spike") || other.CompareTag("Skeleton") || other.CompareTag("Demon"))
        {
            // Zararlı obje listede değilse eklenir
            if (!damagingObjects.Contains(other.gameObject))
            {
                damagingObjects.Add(other.gameObject);
            }
            // İlk defa zararlı bir alana giriliyorsa coroutine başlatılır
            if (!isInTrigger)
            {
                isInTrigger = true;
                damageCoroutine = StartCoroutine(DecreaseHealthOverTime());
            }
        }
    }

    // Zararlı bir objeden çıkıldığında çalışır
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Spike") || other.CompareTag("Skeleton") || other.CompareTag("Demon"))
        {
            // Zararlı obje listeden çıkarılır
            if (damagingObjects.Contains(other.gameObject))
            {
                damagingObjects.Remove(other.gameObject);
            }
            // Zararlı alan kalmadıysa coroutine durdurulur
            if (damagingObjects.Count == 0)
            {
                isInTrigger = false;
                if (damageCoroutine != null)
                {
                    StopCoroutine(damageCoroutine);
                    damageCoroutine = null;
                }
            }
        }
    }

    // Coroutine, düzenli aralıklarla can azaltır
    private IEnumerator DecreaseHealthOverTime()
    {
        while (isInTrigger)
        {
            // Zararlı objelerin aktif olup olmadığını kontrol et
            bool anyActive = false;
            for (int i = 0; i < damagingObjects.Count; i++)
            {
                if (damagingObjects[i] != null && damagingObjects[i].activeInHierarchy)
                {
                    anyActive = true;
                    break;
                }
            }
            // Eğer aktif bir zararlı obje yoksa coroutine durdur
            if (!anyActive)
            {
                isInTrigger = false;
                damageCoroutine = null;
                yield break;
            }

            healthbar.UpdateHealth(-5); // Can 5 birim azaltılır
            yield return new WaitForSeconds(2f); // 2 saniye beklenir
        }
        damageCoroutine = null; // Coroutine sona erdiğinde null olarak ayarlanır
    }
}
