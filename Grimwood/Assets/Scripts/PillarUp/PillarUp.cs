using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarUp : MonoBehaviour
{
    public GameObject[] objectsToMove; // 9 game object
    public Transform[] targetPositions; // 9 transform
    public float speed = 1.0f;

    private bool[] hasReachedTarget;
    private bool[] shouldMove;
    private bool isPlayerInTrigger = false;

    private void Start()
    {
        // Initialize the arrays based on the length of objectsToMove
        int length = objectsToMove.Length;
        hasReachedTarget = new bool[length];
        shouldMove = new bool[length];
    }

    private void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            for (int i = 0; i < objectsToMove.Length; i++)
            {
                shouldMove[i] = true;
            }
        }

        for (int i = 0; i < objectsToMove.Length; i++)
        {
            if (objectsToMove[i] != null && targetPositions[i] != null && !hasReachedTarget[i] && shouldMove[i])
            {
                objectsToMove[i].transform.position = Vector3.MoveTowards(objectsToMove[i].transform.position, targetPositions[i].position, speed * Time.deltaTime);

                if (objectsToMove[i].transform.position == targetPositions[i].position)
                {
                    hasReachedTarget[i] = true;
                    shouldMove[i] = false;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
        }
    }
}
