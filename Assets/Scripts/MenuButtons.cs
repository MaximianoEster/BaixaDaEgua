using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;     

public class MenuButtons : MonoBehaviour
{
    public GameObject mainMenuUI;
    public GameObject optionsMenuUI;

    
    public AudioClip playButtonSound;
    public AudioClip bgMusicMenu;

    public AudioSource audioSource;
    

    public float startWaitTime;
    private float waitTime;

    public float startWaitTimeFade;
    private float waitTimeFade;

    public GameObject startAnim;
    public GameObject creditsAnim;
    public GameObject quitAnim;

    public GameObject creditos;
    
    public Animator transitionAnim;
    public GameObject fade;

    public GameObject menu2;

    void Start()
    {
        //audioSource.Play(bgMusicMenu);
        waitTime = startWaitTime;
        waitTimeFade = startWaitTimeFade;
        
    }

    void Update()
    {
        waitTime -= Time.deltaTime;
            if (waitTime < 0)
            {
                //waitTime = startWaitTime;
                startAnim.SetActive(false);
                creditsAnim.SetActive(false);
                quitAnim.SetActive(false);
                mainMenuUI.SetActive(true);
            }

           if(Input.GetKeyDown("escape"))
       {
           creditos.SetActive(false);
       }
    }
    public void playGame()
    {
        //SceneManager.LoadScene("Fase1");
        
        audioSource.PlayOneShot(playButtonSound, 0.3f);
        StartCoroutine(loadScene());   
    }

    public void quitGame()
    {
        Application.Quit();
        print("Saiu");
    }

    public void credits()
    {
       StartCoroutine(loadCredits());
       audioSource.PlayOneShot(playButtonSound, 0.3f);
       StartCoroutine(loadCredits());
       
       
    }

    IEnumerator loadScene()
    {
        fade.SetActive(true);
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("scene1"); 
    }

     IEnumerator loadCredits()
    {
        fade.SetActive(true);
        yield return new WaitForSeconds(2);
        fade.SetActive(false);
        creditos.SetActive(true); 
        yield return new WaitForSeconds(45);
        creditos.SetActive(false);
    }
}
