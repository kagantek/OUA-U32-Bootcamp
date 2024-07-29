using System.Collections;
using UnityEngine;
using TMPro;

public class RadialMenuController : MonoBehaviour
{
    public GameObject theMenu;
    public Vector2 moveInput;
    public TextMeshProUGUI[] options;
    public Color normalColor, highlightedColor;
    public int selectedOption;
    public GameObject highlightBlock;
    public GameObject targetObject;
    public Transform[] positionSources;

    public Animator animator;
    private bool isPlaying = false;


    public bool canOpenMenu = false;    
    public TextMeshProUGUI countdownText; 
    public float cooldownTime = 30.0f; 
    private bool isCoolingDown = false; 
    
    void Start()
    {        
        theMenu.SetActive(false);
        countdownText.text = "0"; 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canOpenMenu && !isCoolingDown)
        {
            theMenu.SetActive(!theMenu.activeSelf);            
        }

        if (theMenu.activeInHierarchy)
        {
            moveInput.x = Input.mousePosition.x - (Screen.width / 2f);
            moveInput.y = Input.mousePosition.y - (Screen.height / 2f);
            moveInput.Normalize();

            if (moveInput != Vector2.zero)
            {
                float angle = Mathf.Atan2(moveInput.y, -moveInput.x) / Mathf.PI;
                angle *= 180;
                angle -= 90;
                if (angle < 0)
                {
                    angle += 360;
                }

                for (int i = 0; i < options.Length; i++)
                {
                    if (angle > i * (360 / options.Length) && angle < (i + 1) * (360 / options.Length))
                    {
                        options[i].color = highlightedColor;
                        selectedOption = i;

                        highlightBlock.transform.rotation = Quaternion.Euler(0, 0, i * -72);
                    }
                    else
                    {
                        options[i].color = normalColor;
                    }
                }
            }

            if (Input.GetMouseButtonDown(0))
            {
                switch (selectedOption)
                {
                    case 0:
                        TeleportToPosition(0);
                        break;

                    case 1:
                        TeleportToPosition(1);
                        break;

                    case 2:
                        TeleportToPosition(2);
                        break;

                    case 3:
                        TeleportToPosition(3);
                        break;

                    case 4:
                        TeleportToPosition(4);
                        break;
                }
            }
        }
    }

    private void TeleportToPosition(int index)
    {
        if (targetObject != null && index >= 0 && index < positionSources.Length)
        {
            if (theMenu.activeSelf)
            {
                StartCoroutine(StartCooldown()); 
            }
            targetObject.transform.position = positionSources[index].position;
            theMenu.SetActive(!theMenu.activeSelf);
        }
    }

    public void SetCanOpenMenu(bool value)
    {
        canOpenMenu = value;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obelisk"))
        {
            canOpenMenu = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Obelisk"))
        {
            canOpenMenu = false;
        }
    }

    private IEnumerator StartCooldown()
    {
        isCoolingDown = true;
        float remainingTime = cooldownTime;
        isPlaying = true;        

        while (remainingTime > 0)
        {
            countdownText.text = Mathf.Ceil(remainingTime).ToString();
            yield return null; // Wait for the next frame
            remainingTime -= Time.deltaTime; // Decrease time based on the time passed since last frame
            animator.SetBool("isPlaying", isPlaying);
        }

        countdownText.text = "0";
        isCoolingDown = false;
        isPlaying = false;
        animator.SetBool("isPlaying", isPlaying);
    }    
}
