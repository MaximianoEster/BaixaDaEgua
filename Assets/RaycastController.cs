using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastController : MonoBehaviour
{
    public Transform hitPoint;
    public bool limite = false;
    public float limitX;
    // Update is called once per frame
    void Update()
    {
        shot();
    }

    void shot()
    {
        limitX = Screen.width * .004f;
        RaycastHit2D hitInfo = Physics2D.Raycast(hitPoint.position, hitPoint.right, limitX);

        if (hitInfo)
        {
            if (hitInfo.transform.name == "limiteTela")
            {
                limite = true;
            } 
        }
    }
}
