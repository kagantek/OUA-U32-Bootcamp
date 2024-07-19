using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    private Color originalColor;
    public Color highlightColor = Color.yellow;
    private Renderer itemRenderer;

    void Start()
    {
        itemRenderer = GetComponent<Renderer>();
        originalColor = itemRenderer.material.color;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            itemRenderer.material.color = highlightColor;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            itemRenderer.material.color = originalColor;
        }
    }
}
