using System.Collections;
using UnityEngine;
using TMPro;

public class TeleportationController : MonoBehaviour
{
    public GameObject theMenu; 
    public bool canOpenMenu = false;    
    public TextMeshProUGUI countdownText; 
    public float cooldownTime = 10.0f; 
    private bool isCoolingDown = false; 

    void Start()
    {        
        theMenu.SetActive(false);
        countdownText.text = ""; 
    }

    void Update()
    {        
        if (Input.GetKeyDown(KeyCode.E) && canOpenMenu && !isCoolingDown)
        {
            theMenu.SetActive(!theMenu.activeSelf);
            if (theMenu.activeSelf)
            {
                StartCoroutine(StartCooldown()); 
            }
        }
    }
    
    public void SetCanOpenMenu(bool value)
    {
        canOpenMenu = value;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canOpenMenu = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canOpenMenu = false;
        }
    }

    private IEnumerator StartCooldown()
    {
        isCoolingDown = true;
        float remainingTime = cooldownTime;
        while (remainingTime > 0)
        {
            countdownText.text = Mathf.Ceil(remainingTime).ToString(); 
            yield return new WaitForSeconds(1.0f); 
            remainingTime -= 1.0f;
        }
        countdownText.text = ""; 
        isCoolingDown = false;
    }
}
