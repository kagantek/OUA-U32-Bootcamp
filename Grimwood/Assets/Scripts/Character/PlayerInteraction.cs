using UnityEngine;
using System.Collections;

public class PlayerInteraction : MonoBehaviour
{
    private Animator animator;
    public float interactionRange = 1.0f;
    public LayerMask interactableLayer;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            CheckForInteractables();
        }
    }

    void CheckForInteractables()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, interactionRange, interactableLayer);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Collectible"))
            {
                StartCoroutine(PickupItem(hitCollider.gameObject));
                break;
            }
        }
    }

    IEnumerator PickupItem(GameObject item)
    {
        animator.SetBool("isPickingUp", true);
        yield return new WaitForSeconds(1.0f); // Animasyon süresine göre ayarla
        animator.SetBool("isPickingUp", false);

        Destroy(item);
    }
}
