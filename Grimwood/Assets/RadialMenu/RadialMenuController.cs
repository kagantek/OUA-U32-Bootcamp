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

    void Update()
    {
        if (theMenu.activeInHierarchy)
        {
            
            moveInput.x = Input.mousePosition.x - (Screen.width / 2f);
            moveInput.y = Input.mousePosition.y - (Screen.height / 2f);
            moveInput.Normalize();

            
            selectedOption = -1;

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

                        highlightBlock.transform.rotation = Quaternion.Euler(0, 0, i * (-360 / options.Length));
                    }
                    else
                    {
                        options[i].color = normalColor;
                    }
                }
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (selectedOption >= 0)
                {
                    TeleportToPosition(selectedOption);
                    selectedOption = -1;
                }
            }
        }
    }

    private void TeleportToPosition(int index)
    {
        if (targetObject != null && index >= 0 && index < positionSources.Length)
        {
            targetObject.transform.position = positionSources[index].position;
            theMenu.SetActive(false);
        }
    }
}
