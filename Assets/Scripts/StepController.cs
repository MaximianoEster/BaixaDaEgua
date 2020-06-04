using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepController : MonoBehaviour
{
    [SerializeField] private AudioClip[] sonsAndar;
    private AudioSource audioSource;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Walk()
    {
        AudioClip somAndar = GetRandomClip();
        audioSource.PlayOneShot(somAndar, .05f);
    }

    private AudioClip GetRandomClip()
    {
        return sonsAndar[UnityEngine.Random.Range(0, sonsAndar.Length)];
    }
}
