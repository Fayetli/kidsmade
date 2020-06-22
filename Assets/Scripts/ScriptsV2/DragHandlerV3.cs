using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragHandlerV3 : MonoBehaviour
{
    private Transform startParent;

    public bool MouseDown = false;

    bool trigger = false;

    GameObject slotCollider;
    private void OnMouseDown()
    {
        startParent = transform.parent;
        MouseDown = true;
        this.GetComponent<SpriteRenderer>().sortingOrder++;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "SlotIn")
        {
            Debug.Log("Enter trigger: " + other.name);
            trigger = true;
            this.slotCollider = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        trigger = false;//
        this.slotCollider = null;
    }

    private void OnMouseUp()
    {
        MouseDown = false;

        this.GetComponent<SpriteRenderer>().sortingOrder--;

        if (trigger == true)
        {
            if (slotCollider.transform.childCount == 0)
            {
                Debug.Log("Use collision without slotchild");

                this.transform.SetParent(slotCollider.transform);
                startParent = this.transform.parent;

                GameObject.Find("SlotData").GetComponent<SlotData>().ActivateButton();

                this.GetComponent<JsonSaver>().LoadSpriteTransform();//change transform
                //this.GetComponent<JsonSaver>().TakeToStartTransform();
                //this.GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {
                Debug.Log("Use collision with slotchild");

                GameObject aux = slotCollider.transform.GetChild(0).gameObject;
                this.transform.SetParent(slotCollider.transform);

                aux.transform.SetParent(startParent.transform);
                startParent = this.transform.parent;

                //this.GetComponent<SpriteRenderer>().enabled = false;
                aux.GetComponent<SpriteRenderer>().enabled = true;

                aux.GetComponent<JsonSaver>().TakeToStartTransform();//change transform

                this.GetComponent<JsonSaver>().LoadSpriteTransform();//change transform
            }
            trigger = false;
        }
    }



    private void Update()
    {
        Vector2 Cursor = Input.mousePosition;
        Cursor = Camera.main.ScreenToWorldPoint(Cursor);

        if (MouseDown == true)
        {
            this.transform.position = Cursor;
        }
        else
        {
            if(this.gameObject.transform.parent.gameObject.tag != "SlotIn")
                this.transform.localPosition = new Vector3(0, 0, 0);
        }
    }
}
