using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextButtonScript : MonoBehaviour
{
    public GameObject currentSlot = null;
    public GameObject nextSlot = null;
    public GameObject currentPanel = null;
    public GameObject nextPanel = null;
    public void ActivateNextSlot()
    {
        currentSlot.gameObject.GetComponent<SlotInScript>().CanUse = false;
        currentSlot.gameObject.GetComponent<SpriteRenderer>().enabled = false;

        nextSlot.gameObject.SetActive(true);
        currentSlot.SetActive(false);

        nextPanel.gameObject.SetActive(true);
        currentPanel.gameObject.SetActive(false);
    }
}
