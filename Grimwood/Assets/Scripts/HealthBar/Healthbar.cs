using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Healthbar : MonoBehaviour
{    
    private float maxHealth = 100;
    private float currentHealth;
    [SerializeField] private UnityEngine.UI.Image healthBarFill;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private Gradient colorGradient;

    [SerializeField] private GameOver gameOverScript;

    void Start()
    {
        currentHealth = maxHealth;
        healthText.text = "Health: " + currentHealth;
    }

    public void UpdateHealth(float amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        healthText.text = "Health: " + currentHealth;
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            gameOverScript.ShowGameOverMenu();
        }
    }

    private void UpdateHealthBar()
    {
        float targetFillAmount = currentHealth / maxHealth;
        healthBarFill.fillAmount = targetFillAmount;
        healthBarFill.color = colorGradient.Evaluate(targetFillAmount);
    }
}
