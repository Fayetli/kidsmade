using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishScript : MonoBehaviour
{
    [SerializeField] private SlotData _slotData;

    public void activateTruePictures()
    {
        _slotData.LoadFinishSprites();
    }




}
