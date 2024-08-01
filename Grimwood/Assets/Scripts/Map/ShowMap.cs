using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMap : MonoBehaviour
{
    public GameObject targetObject;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            targetObject.SetActive(!targetObject.activeSelf);
        }
    }
}
