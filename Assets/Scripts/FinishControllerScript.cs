using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishControllerScript : MonoBehaviour
{
    public GameObject button;
    bool activateButton = true;

    public void Update()
    {
        if (transform.childCount > 0 && button.gameObject.activeInHierarchy == false)
        {
            
            if (activateButton == true)
            {
                button.gameObject.SetActive(true);
                activateButton = false;
            }
        }

    }

}