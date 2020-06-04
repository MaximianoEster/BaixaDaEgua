using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject maria;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(loadScene());
    }

    IEnumerator loadScene()
    {
        gameObject.SetActive(true);
        maria.SetActive(true);
        yield return new WaitForSeconds(4f);
        gameObject.SetActive(false);
        maria.SetActive(false);
    }
}
