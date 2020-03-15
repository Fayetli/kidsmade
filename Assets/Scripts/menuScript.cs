using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuScript : MonoBehaviour
{
    public GameObject HUD;
    public GameObject SlotsOutPanel;
    public GameObject SlotIn;

    public void playButton()
    {
        GameObject.Find("mainMenu").SetActive(false);
        HUD.SetActive(true);
        Invoke("startAnimation", 1);
    }

    void startAnimation()
    {
        GameObject.Find("controller").GetComponent<Animator>().SetBool("is_ACTIVE", true);
        Invoke("startHUD", 1);
    }

    private void startHUD()
    {
        SlotsOutPanel.SetActive(true);
        SlotIn.SetActive(true);

    }

}
