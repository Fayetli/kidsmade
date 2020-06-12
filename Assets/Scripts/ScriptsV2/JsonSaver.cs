using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonSaver : MonoBehaviour
{
    string json;

    Vector3 startPosition;
    Quaternion startRotation;
    Vector3 startScale;

    private void Start()
    {
        startPosition = this.transform.localPosition;
        startRotation = this.transform.rotation;
        startScale = this.transform.localScale;
    }

    void SaveSpriteTransorm()
    {
        SaveTransform data = new SaveTransform();

        data.position = this.transform.localPosition;
        data.rotation = this.transform.rotation;
        data.scale = this.transform.localScale;

        json = JsonUtility.ToJson(data, true);
        Debug.Log(json);

        //string name = "D:/" + this.name + ".txt";//

        //File.WriteAllText("D:/save.txt", json);
    }

    void SetSpriteTransform()
    {
        //string json;
        //json = File.ReadAllText("D:/save.txt");

        if (json != null && json.Length > 0)
        {
            SaveTransform data = null;
            JsonUtility.FromJsonOverwrite(json, data);

            if (data != null)
            {
                this.transform.localPosition = data.position;
                this.transform.localScale = data.scale;
                this.transform.rotation = data.rotation;
            }
        }
    }


    private void Update()//example
    {
        if (Input.GetKeyDown(KeyCode.S))
            SaveSpriteTransorm();
        if (Input.GetKeyDown(KeyCode.L))
            SetSpriteTransform();
    }

    
}
