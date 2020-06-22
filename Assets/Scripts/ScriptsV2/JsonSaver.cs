using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
public class JsonSaver : MonoBehaviour
{
    string json;

    Vector3 startPosition;
    Quaternion startRotation;
    Vector3 startScale;

    public class SaveTransform
    {
        public Vector3 position;
        public Quaternion rotation;
        public Vector3 scale;
    }
    private void Start()
    {
        startPosition = this.transform.localPosition;
        startRotation = this.transform.rotation;
        startScale = this.transform.localScale;
    }

    public bool writing;
    public void SaveSpriteTransorm()
    {
        if (!writing)
            return;
        SaveTransform data = new SaveTransform();

        data.position = this.transform.localPosition;
        data.rotation = this.transform.rotation;
        data.scale = this.transform.localScale;

        json = JsonUtility.ToJson(data, true);
        Debug.Log(json);

        string sceneName = SceneManager.GetActiveScene().name;
        string path = Application.dataPath + "/Resources/" + sceneName ;

        Directory.CreateDirectory(path);

        int stateNumber = GameObject.Find("SlotData").GetComponent<SlotData>().GetCounter();
        string jsonName = this.name + ".json";

        path += "/" + stateNumber + "_" + jsonName;

        Debug.Log(path);
        File.WriteAllText(path, json);
    }

    public void LoadSpriteTransform()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        int stateNumber = GameObject.Find("SlotData").GetComponent<SlotData>().GetCounter();
        string jsonName = this.name;

        string path = sceneName + '/' + stateNumber + '_' + jsonName;

        Debug.Log(path);

        json = Resources.Load<TextAsset>(path).ToString();

        Debug.Log(json);

        SaveTransform data = JsonUtility.FromJson<SaveTransform>(json);

        this.transform.localPosition = data.position;
        this.transform.localScale = data.scale;
        this.transform.rotation = data.rotation;

    }


    private void Update()//example
    {
        if (Input.GetKeyDown(KeyCode.S))
            SaveSpriteTransorm();
        if (Input.GetKeyDown(KeyCode.L))
            LoadSpriteTransform();
    }


    public void TakeToStartTransform()
    {
        this.transform.localPosition = startPosition;
        this.transform.rotation = startRotation;
        this.transform.localScale = startScale;
    }
}
