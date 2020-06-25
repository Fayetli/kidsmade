using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using System;

public class JsonSaver : MonoBehaviour
{
    Vector3 startPosition;
    Quaternion startRotation;
    Vector3 startScale;

    SlotData.SpritesTransformData.SaveTransform savedTransform = new SlotData.SpritesTransformData.SaveTransform();
    public class SaveTransform
    {
        public Vector3 position;
        public Quaternion rotation;
        public Vector3 scale;
        public string name;
    }
    private void Start()
    {
        startPosition = this.transform.localPosition;
        startRotation = this.transform.rotation;
        startScale = this.transform.localScale;
    }

    public void SetSpriteTransorm(SlotData.SpritesTransformData.SaveTransform save)
    {
        savedTransform = save;
    }

    public SlotData.SpritesTransformData.SaveTransform GetSaveTransform()
    {
        SlotData.SpritesTransformData.SaveTransform save = new SlotData.SpritesTransformData.SaveTransform();
        save.position = this.transform.localPosition;
        save.rotation = this.transform.rotation;
        save.scale = this.transform.localScale;
        save.name = this.name;

        return save;
    }

    public void LoadSpriteTransform()
    {
        this.transform.localPosition = savedTransform.position;
        this.transform.localScale = savedTransform.scale;
        this.transform.rotation = savedTransform.rotation;
    }

    public void TakeToStartTransform()
    {
        this.transform.localPosition = startPosition;
        this.transform.rotation = startRotation;
        this.transform.localScale = startScale;
    }
}
