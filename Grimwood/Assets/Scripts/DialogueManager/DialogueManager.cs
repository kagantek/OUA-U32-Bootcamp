using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI npcNameText;
    public GameObject dialoguePanel;

    public void DisplayText(string text1, string text2)
    {
        dialogueText.text = text1;
        npcNameText.text = text2;
        dialogueText.gameObject.SetActive(!dialogueText.gameObject.activeSelf);
        npcNameText.gameObject.SetActive(!npcNameText.gameObject.activeSelf);
        dialoguePanel.SetActive(!dialoguePanel.gameObject.activeSelf);
    }

    public void CloseText()
    {
        dialogueText.gameObject.SetActive(false);
        npcNameText.gameObject.SetActive(false);
        dialoguePanel.SetActive(false);
    }
    
}