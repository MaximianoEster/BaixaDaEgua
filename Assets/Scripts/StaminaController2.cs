using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaController2 : MonoBehaviour
{
    public Image staminaBar;
    public float TotalStamina, CurrentStamina, CurrentStamina2;
    public float StaminaGain = 5f;
    GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.gameManager;
        staminaBar = GetComponent<Image>();
        TotalStamina = 5f;
        CurrentStamina = 0f;
        CurrentStamina2 = 5f;
        staminaBar.fillAmount = CurrentStamina;
    }

    void Update()
    {
        GainStamina();
        UpdateStamina();
    }
    public void GainStamina()
    {
        CurrentStamina = Mathf.Lerp(CurrentStamina, gameManager.vida, StaminaGain * Time.deltaTime);
    }

    public void UpdateStamina()
    {
        staminaBar.fillAmount = CurrentStamina / TotalStamina;
    }
}