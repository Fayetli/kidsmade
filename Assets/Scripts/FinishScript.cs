using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishScript : MonoBehaviour
{
    public GameObject[] slots;
    public Text FinishText;
    public GameObject[] cases;

    int correctAnswers = 0;
    int allAnswers;
    private void Start()
    {

    }
    int i = 0;
    void activateTruePictures()
    {
        slots[i].transform.GetChild(0).gameObject.SetActive(false);

        if (slots[i].transform.GetChild(0).gameObject.tag == "1c") 
        {
            cases[i].transform.GetChild(1).gameObject.SetActive(false);
            cases[i].transform.GetChild(0).gameObject.SetActive(true);
            Debug.Log("finish" + i + 1);
        }
        else if (slots[i].transform.GetChild(0).gameObject.tag == "2c")
        {
            cases[i].transform.GetChild(3).gameObject.SetActive(false);
            cases[i].transform.GetChild(2).gameObject.SetActive(true);
            Debug.Log("finish");
        }
        else if (slots[i].transform.GetChild(0).gameObject.tag == "3c")
        {
            cases[i].transform.GetChild(5).gameObject.SetActive(false);
            cases[i].transform.GetChild(4).gameObject.SetActive(true);
            Debug.Log("finish");
        }
        i++;
        
    }
    public void finishButton()
    {
        slots[3].GetComponent<Image>().enabled = false;
        GameObject.Find("SlotsOutPanel").SetActive(false);
        GameObject.Find("Button(Finish)").SetActive(false);

        foreach (GameObject obj in slots)
        {
            allAnswers++;
            
            Invoke("activateTruePictures", allAnswers);
            /*
            if (obj.gameObject.transform.GetChild(0).transform.tag == "true")
            {
                correctAnswers++;
            }
            */
        }

        /*
        float procentCorrectAnswers = 0;
        if (correctAnswers > 0)
        {
            procentCorrectAnswers = correctAnswers * 100 / allAnswers;
        }
        */
        
    }



}
