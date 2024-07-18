using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class InputSystem : MonoBehaviour
{
    Movement moveScript;

    [System.Serializable]
    public class InputSettings
    {
        public string forwardInput = "Vertical";
        public string strafeInput = "Horizontal";
        public string sprintInput = "Sprint";
        public string jumpInput = "Jump";
    }

    [SerializeField]
    public InputSettings input;

    void Start()
    {
        moveScript = GetComponent<Movement>();
    }

    void Update()
    {
        moveScript.AnimateCharacter(Input.GetAxis(input.forwardInput), Input.GetAxis(input.strafeInput));
        moveScript.SprintCharacter(Input.GetButton(input.sprintInput));

        if (Input.GetButtonDown(input.jumpInput))
        {
            moveScript.JumpCharacter();
        }
    }
}
