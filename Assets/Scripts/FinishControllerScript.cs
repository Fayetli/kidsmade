using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishControllerScript : MonoBehaviour
{
    public GameObject button;
    bool activateButton = true;

    public void Update()
    {
        //optimize here
        if (transform.childCount > 0 /*&& button.gameObject.activeSelf == false*/)
        {
            
            if (activateButton == true)
            {
                button.gameObject.SetActive(true);
                activateButton = false;
            }
        }

    }

}