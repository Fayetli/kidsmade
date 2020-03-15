using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteData
{
    public string title = null;
    public Vector3 position = new Vector3(0,0,0);
    public Quaternion rotation = new Quaternion(0, 0, 0, 1);
    public Vector3 scale = new Vector3(0, 0, 0);

    public spriteData(string title, Vector3 position, Quaternion rotation, Vector3 scale)
    {
        this.title = title;
        this.position = position;
        this.rotation = rotation;
        this.scale = scale;
    }
    public spriteData()
    {

    }
}
