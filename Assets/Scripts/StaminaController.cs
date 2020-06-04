using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaController : MonoBehaviour
{
    public Image staminaBar;
    public float TotalStamina, CurrentStamina;
    public float StaminaGain = 5f;
    GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.gameManager;
        staminaBar = GetComponent<Image>();
        TotalStamina = 100;
        CurrentStamina = gameManager.staminaMana;
        staminaBar.fillAmount = gameManager.staminaMana;
    }

    void Update()
    {
        GainStamina();
        UpdateStamina();
    }
    public void GainStamina(){
        if (CurrentStamina < 100){
            CurrentStamina = Mathf.Lerp(CurrentStamina, TotalStamina, StaminaGain * Time.deltaTime);
        }
    }
    public void UpdateStamina(){
        staminaBar.fillAmount = gameManager.staminaMana = CurrentStamina/TotalStamina;
    }

    public void LoseStamina(float Cost){
        CurrentStamina -= Cost;
        gameManager.staminaMana -= Cost;
        staminaBar.fillAmount = CurrentStamina/TotalStamina;
    }
}