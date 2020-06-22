using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class SlotData : MonoBehaviour
{
    private GameObject[] slotsIn;
    private GameObject[] panelsSlotsOut;
    private int counter = 0;



    public GameObject buttonNext;
    public GameObject buttonFinish;

    public int GetCounter() { return counter; }

    void BubbleSort(GameObject[] array)//sorting for indexes
    {
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = 0; j < array.Length - 1; j++)
            {
                int indexX, indexY;//ref it
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
    void Start()//find all slotsIn, Panels with slotsOut, disable all and activate only firsts
    {
        buttonNext.SetActive(false);
        buttonFinish.SetActive(false);

        counter = 0;

        slotsIn = GameObject.FindGameObjectsWithTag("SlotIn");
        foreach (GameObject x in slotsIn)
        {
            x.gameObject.SetActive(false);
            x.transform.localPosition = new Vector3(0, 0, -5.0f);//fix object slot
            slotsIn[counter].GetComponent<Collider2D>().enabled = false;//
        }

        BubbleSort(slotsIn);
        slotsIn[counter].SetActive(true);
        slotsIn[counter].GetComponent<Collider2D>().enabled = true;//

        panelsSlotsOut = GameObject.FindGameObjectsWithTag("PanelSlotOut");
        foreach (GameObject x in panelsSlotsOut)
        {
            x.gameObject.SetActive(false);
        }

        BubbleSort(panelsSlotsOut);
        panelsSlotsOut[counter].SetActive(true);
    }

    public void ActivateNextSlot()//disable current slot and panel and activate next slot and panel
    {
        Debug.Log("ActivateNextSlot");

        slotsIn[counter].GetComponent<SpriteRenderer>().enabled = false;
        slotsIn[counter].GetComponent<Collider2D>().enabled = false;
        slotsIn[counter].transform.GetChild(0).gameObject.GetComponent<Collider2D>().enabled = false;

        panelsSlotsOut[counter].SetActive(false);

        counter++;

        if (counter < slotsIn.Length)
        {
            slotsIn[counter].SetActive(true);
            slotsIn[counter].GetComponent<SpriteRenderer>().enabled = true;
            slotsIn[counter].GetComponent<Collider2D>().enabled = true;
        }
        
        if(counter < panelsSlotsOut.Length)
            panelsSlotsOut[counter].SetActive(true);
    }

    public void ActivateButton()//activate button "next" or button "finish" if it`s last slot
    {
        if (counter < slotsIn.Length - 1)
        {
            Debug.Log("Counter: " + counter + ", button next activated!");
            if (!buttonNext.gameObject.activeInHierarchy)
            {
                buttonNext.gameObject.SetActive(true);
            }
        }
        else if (counter == slotsIn.Length - 1)
        {
            Debug.Log("Counter: " + counter + ", button finish activated!");
            if (!buttonFinish.gameObject.activeInHierarchy)
            {
                buttonFinish.gameObject.SetActive(true);
            }
        }
    }
}
