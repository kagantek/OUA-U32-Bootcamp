using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI  dialogueText;

    public void DisplayText(string text)
    {
        dialogueText.text = text;
        dialogueText.gameObject.SetActive(!dialogueText.gameObject.activeSelf);
    }
}