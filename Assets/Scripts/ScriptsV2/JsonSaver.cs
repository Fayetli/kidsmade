using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonSaver : MonoBehaviour
{

    void TransformSaving()
    {
        SaveTransform save = new SaveTransform();

        save.positionX = this.transform.localPosition.x;
        save.positionY = this.transform.localPosition.y;

        save.scaleX = this.transform.localScale.x;
        save.scaleY = this.transform.localScale.y;

        save.rotationZ = this.transform.rotation.z;


        string json = JsonUtility.ToJson(save);
        Debug.Log(json);

        string name = "prt_1_" + this.name;//change it

        PlayerPrefs.SetString("trsave", json);//name //don`t use PlayerPrefs

    }



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
            TransformSaving();
    }
}
