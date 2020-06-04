using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaController3 : MonoBehaviour
{
    public Image staminaBar;
    public float TotalStamina, CurrentStamina, CurrentStamina2;
    public float StaminaGain = 5f;
    GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.gameManager;
        staminaBar = GetComponent<Image>();
        TotalStamina = 100;
        CurrentStamina = gameManager.staminaPadre;
    }

    void Update()
    {
        GainStamina();
        UpdateStamina();
    }
    public void GainStamina()
    {
        if (CurrentStamina < 100)
        {
            CurrentStamina = Mathf.Lerp(CurrentStamina, CurrentStamina2, StaminaGain * Time.deltaTime);
        }
    }
    public void UpdateStamina()
    {
        staminaBar.fillAmount = gameManager.staminaPadre = CurrentStamina / TotalStamina;
    }

    public void LoseStamina(float Cost)
    {
        CurrentStamina -= Cost;
        gameManager.staminaPadre -= Cost;
        staminaBar.fillAmount = CurrentStamina / TotalStamina;
    }
}