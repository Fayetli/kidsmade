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
            //optimize here
            if (transform.childCount > 0 /*&& button.gameObject.activeSelf == false*/)
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

}
