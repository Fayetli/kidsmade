using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsJson : MonoBehaviour
{
    public GameObject obj;
    string filename = "data.json";
    string path;
    private void Start()
    {
        spriteData sprite = new spriteData()/* = new spriteData(obj.name, obj.transform.position, obj.transform.localRotation, obj.transform.localScale)*/;
        path = Application.persistentDataPath + "/" + filename;
        Debug.Log(path);
        //SaveData(sprite);
        ReadData(sprite);
    }

    void SaveData(spriteData sprite)
    {
        string content = JsonUtility.ToJson(sprite, true);
        System.IO.File.WriteAllText(path, content);
    }
    void ReadData(spriteData sprite)
    {

    }


}
