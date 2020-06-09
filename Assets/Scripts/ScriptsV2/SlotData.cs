using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class SlotData : MonoBehaviour
{
    public GameObject[] slotsIn;
    public GameObject[] panelsSlotsOut;
    private int counter = 0;

    void BubbleSort(GameObject[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = 0; j < array.Length - 1; j++)
            {
                int indexX, indexY;
                int.TryParse(string.Join("", array[j].name.Where(c => char.IsDigit(c))), out indexX);
                int.TryParse(string.Join("", array[j + 1].name.Where(c => char.IsDigit(c))), out indexY);

                if (indexX > indexY)
                {
                    GameObject temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
        Debug.Log("Sorting Complete!");
    }
    void Start()
    {
        slotsIn = GameObject.FindGameObjectsWithTag("SlotIn");

        foreach (GameObject x in slotsIn)
        {
            x.gameObject.SetActive(false);
            x.transform.localPosition = new Vector3(0, 0, -5.0f);//fix object slot //+refactoring
        }

        BubbleSort(slotsIn);
        slotsIn[0].SetActive(true);
        counter = 0;

        panelsSlotsOut = GameObject.FindGameObjectsWithTag("PanelSlotOut");

        foreach (GameObject x in panelsSlotsOut)
        {
            x.gameObject.SetActive(false);
        }

        BubbleSort(panelsSlotsOut);
        panelsSlotsOut[0].SetActive(true);
    }

    public void ActivateNextSlot()
    {
        Debug.Log("ActivateNextSlot");

        slotsIn[counter].GetComponent<SpriteRenderer>().enabled = false;
        slotsIn[counter].GetComponent<SlotInScript>().CanUse = false;

        panelsSlotsOut[counter].SetActive(false);

        counter++;

        slotsIn[counter].SetActive(true);
        slotsIn[counter].GetComponent<SpriteRenderer>().enabled = true;
        slotsIn[counter].GetComponent<SlotInScript>().CanUse = true;

        panelsSlotsOut[counter].SetActive(true);


    }

    // Update is called once per frame
    void Update()
    {

    }
}
