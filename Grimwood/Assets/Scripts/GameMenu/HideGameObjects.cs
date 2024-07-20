using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideGameObjects : MonoBehaviour
{
    public GameObject objectToHide;

    public void OnButtonClick()
    {
        objectToHide.SetActive(false);
    }
}
