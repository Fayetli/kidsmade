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
    //public Canvas EndCanvas;

    int correctAnswers = 0;
    int allAnswers;
    private void Start()
    {

    }
    int i = 0;
    void activateTruePictures()
    {
        if (slots[i].gameObject.transform.GetChild(0).gameObject.tag == "1c") {
            GameObject truePicture = cases[i].transform.GetChild(2).gameObject;
            truePicture.SetActive(true);
        }
        else if (slots[i].gameObject.transform.GetChild(0).gameObject.tag == "2c")
        {
            GameObject truePicture = cases[i].transform.GetChild(4).gameObject;
            truePicture.SetActive(true);
        }
        else if (slots[i].gameObject.transform.GetChild(0).gameObject.tag == "3c")
        {
            GameObject truePicture = cases[i].transform.GetChild(4).gameObject;
            truePicture.SetActive(true);
        }
        i++;
    }
    public void finishButton()
    {

        foreach (GameObject obj in slots)
        {
            allAnswers++;
            
            //Invoke("activateTruePictures", allAnswers * 2);
            if (obj.gameObject.transform.GetChild(0).transform.tag == "true")
            {
                correctAnswers++;
            }
        }

        float procentCorrectAnswers = 0;
        if (correctAnswers > 0)
        {
            procentCorrectAnswers = correctAnswers * 100 / allAnswers;
        }


        //FinishText.text = Convert.ToString(procentCorrectAnswers);
        //EndCanvas.gameObject.SetActive(true);*/
    }



}
