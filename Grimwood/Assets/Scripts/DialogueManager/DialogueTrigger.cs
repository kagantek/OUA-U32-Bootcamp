using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public string dialogueLine = "Hello, traveler!";
    private bool isPlayerInRange = false;
    public DialogueManager dialogueManager; // Reference to the DialogueManager

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            DisplayDialogue();
        }
    }

    void DisplayDialogue()
    {
        dialogueManager.DisplayText(dialogueLine);
        Debug.Log("Merhaba Yolcu");
    }
}
