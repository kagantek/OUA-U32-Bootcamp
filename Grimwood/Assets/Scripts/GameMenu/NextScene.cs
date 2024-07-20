using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public Button myButton;
    private int sceneBuildIndex;

    void Start()
    {
        sceneBuildIndex = SceneManager.GetActiveScene().buildIndex; ;
        myButton.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        SceneManager.LoadScene(sceneBuildIndex + 1);
    }
}
