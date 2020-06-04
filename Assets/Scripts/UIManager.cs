using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text bombaTexto;
    public Text moedaTexto;
    
    // Start is called before the first frame update
    void Awake()
    {
        UpdateMoedasUI();
        UpdateBombasUI();
    }
    private void Update()
    {
        UpdateMoedasUI();
        UpdateBombasUI();
    }
    public void UpdateMoedasUI()
    {
        moedaTexto.text = GameManager.gameManager.moedas.ToString();
    }

    public void UpdateBombasUI()
    {
        bombaTexto.text = GameManager.gameManager.bombas.ToString();
    }

}
