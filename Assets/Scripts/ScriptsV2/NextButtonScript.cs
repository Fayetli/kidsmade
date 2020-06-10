using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextButtonScript : MonoBehaviour
{
    SlotData c;

    private void Start()
    {
        c = GameObject.Find("SlotData").GetComponent<SlotData>();
    }
    public void ActivateNextSlot()
    {
        c.ActivateNextSlot();
        this.gameObject.SetActive(false);
    }
}
