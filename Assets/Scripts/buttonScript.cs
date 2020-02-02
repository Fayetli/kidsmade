using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonScript : MonoBehaviour
{
    public GameObject slot;
    public GameObject nextSlot;
    public GameObject nextPanel;
    public GameObject panel;


    public void activateNextSlot()
    {
        slot.gameObject.GetComponent<ControllerScript>().canSet = false;
        slot.gameObject.GetComponent<Image>().enabled = false;
        nextSlot.gameObject.SetActive(true);
        panel.SetActive(false);
        nextPanel.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
