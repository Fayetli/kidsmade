using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteOuter : MonoBehaviour
{



    void SpawnSprite(GameObject sprite)
    {
        string jsonString = PlayerPrefs.GetString("trsave");//name //don`t use PlayerPrefs

        if (jsonString != null && jsonString.Length > 0)
        {
            SaveTransform save = JsonUtility.FromJson<SaveTransform>(jsonString);

            if (save != null)
            {
                sprite.transform.localPosition = new Vector3(save.positionX, save.positionY, 0.0f);
                sprite.transform.localScale = new Vector3(save.scaleX, save.scaleY, 0.0f);
                sprite.transform.rotation = new Quaternion(0, 0, save.rotationZ, 0);//////////////
                
            }
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
