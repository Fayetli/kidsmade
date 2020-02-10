using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScript : MonoBehaviour
{
    public GameObject button = null;
    public GameObject nextSlot = null;
    public GameObject nextPanel = null;
    public GameObject panel = null;
    public bool canSet = true;
    bool activateButton = true;

    public void Update()
    {
        if (gameObject.transform.tag != "FinishSlot" && canSet != false)
        {
            if (transform.childCount > 0 && button.gameObject.activeInHierarchy == false)
            {
                button.gameObject.GetComponent<buttonScript>().slot = gameObject;
                button.gameObject.GetComponent<buttonScript>().nextSlot = nextSlot;
                button.gameObject.GetComponent<buttonScript>().nextPanel = nextPanel;
                button.gameObject.GetComponent<buttonScript>().panel = panel;

                if (activateButton == true)
                {
                    button.gameObject.SetActive(true);
                    activateButton = false;
                }
            }
        }
        else if (gameObject.transform.tag == "FinishSlot")
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

}
