using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.IO;
using UnityEngine.SceneManagement;



public class SlotData : MonoBehaviour//slots and panels activate, save slot_objects to json, load slot_objects from json
{
    private GameObject[] slotsIn;
    private GameObject[] panelsSlotsOut;
    private int counter = 0;

    public bool writing;

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
        if (writing)
            return;
        //
        LoadSpritesTransform();
        //
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

    
    //////////////////////////////////////////////////////////////////////////////////


    public string object_tag = "slot_object";
    public string json_name = "paint_sprites";

    [Serializable]
    public class SpritesTransformData
    {

        public SaveTransform[] transforms;

        [Serializable]
        public class SaveTransform
        {
            public Vector3 position;
            public Quaternion rotation;
            public Vector3 scale;
            public string name;
        }
        public SpritesTransformData(int len)
        {
            transforms = new SaveTransform[len];
        }

        public void SetTransform(SaveTransform obj, int index)
        {
            transforms[index] = new SaveTransform();
            transforms[index] = obj;
        }
        
    };
    void SaveSpritesTransform()
    {
        GameObject[] sprites = GameObject.FindGameObjectsWithTag(object_tag);
        BubbleSort(sprites);//maybe delete

        SpritesTransformData data = new SpritesTransformData(sprites.Length);

        for (int i = 0; i < sprites.Length; i++)
        {
            data.SetTransform(sprites[i].GetComponent<JsonSaver>().GetSaveTransform(), i);
        }

        string sceneName = SceneManager.GetActiveScene().name;
        string path = Application.dataPath + "/Resources/" + sceneName;

        Directory.CreateDirectory(path);//create a directory if directory was not created
        string json = JsonUtility.ToJson(data, true);

        path += "/" + json_name + ".json";

        File.WriteAllText(path, json);

        Debug.Log("Save:" + json);
    }


    void LoadSpritesTransform()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        string path = sceneName + "/" + json_name;

        string json = Resources.Load<TextAsset>(path).ToString();

        Debug.Log("Load:" + json);

        SpritesTransformData data = JsonUtility.FromJson<SpritesTransformData>(json);

        GameObject[] sprites = GameObject.FindGameObjectsWithTag(object_tag);
        BubbleSort(sprites);//maybe delete
 
        for (int i = 0; i < sprites.Length; i++)
        {
            SpritesTransformData.SaveTransform save = data.transforms[i];
            sprites[i].GetComponent<JsonSaver>().SetSpriteTransorm(save);
        }
    }


    public void LoadFinishSprites()
    {
        slotsIn[counter].GetComponent<SpriteRenderer>().enabled = false;
        slotsIn[counter].GetComponent<Collider2D>().enabled = false;
        slotsIn[counter].transform.GetChild(0).gameObject.GetComponent<Collider2D>().enabled = false;



        for (int i = 0; i < slotsIn.Length; i++)
        {
            GameObject paint_sprite = slotsIn[i].transform.GetChild(0).gameObject;

            int num_of_sprite = 0;
            int.TryParse(string.Join("", paint_sprite.name.Where(c => char.IsDigit(c))), out num_of_sprite);

            string sceneName = SceneManager.GetActiveScene().name;
            string path = sceneName + "/" + "Symbols" + "/" + "symbol_";
            if (num_of_sprite < 10)
                path += "0";
            path += num_of_sprite;

            GameObject symbol = Resources.Load(path) as GameObject;
            Instantiate(symbol, slotsIn[i].transform);

            Destroy(paint_sprite);
        }

    }
    //////////////////////////////////////////////////////////////////////////////////


    private void Update()//example
    {
        if (!writing)
            return;
        if (Input.GetKeyDown(KeyCode.S))
            SaveSpritesTransform();
        if (Input.GetKeyDown(KeyCode.L))
            LoadSpritesTransform();
    }
}
