using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowGameObjects : MonoBehaviour
{
    public GameObject objectToShow;

    public void OnButtonClick()
    {
        objectToShow.SetActive(true);
    }
}
