
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.EventSystems;

//public class DragHandler2 : MonoBehaviour
//{
//    private Transform startParent;

//    bool trigger = false;

//    public bool MouseDown = false;

//    //public int index;

    


//    private void OnMouseDown()
//    {
//        startParent = transform.parent;
//        MouseDown = true;
//        this.GetComponent<SpriteRenderer>().sortingOrder++;
//    }

//    private void OnMouseUp()
//    {
//        MouseDown = false;
//        this.GetComponent<SpriteRenderer>().sortingOrder--;
//    }
//    private void OnTriggerEnter2D(Collider2D other)
//    {
//        if (other.transform.tag == "SlotIn")
//            trigger = true;
//    }

//    private void OnTriggerExit2D(Collider2D other)
//    {
//        if (other.transform.tag == "SlotIn" && !MouseDown && other.gameObject.GetComponent<SlotInScript>().CanUse)
//        {
//            if (other.transform.childCount == 0)
//            {
//                Debug.Log("Use collision without slotchild");

//                this.transform.SetParent(other.transform);
//                startParent = this.transform.parent;

//                //this.GetComponent<SpriteRenderer>().enabled = false;
//            }
//            else
//            {
//                Debug.Log("Use collision with slotchild");

//                GameObject aux = other.transform.GetChild(0).gameObject;
//                this.transform.SetParent(other.transform);

//                aux.transform.SetParent(startParent.transform);
//                startParent = this.transform.parent;

//                //this.GetComponent<SpriteRenderer>().enabled = false;
//                aux.GetComponent<SpriteRenderer>().enabled = true;
//            }
//            trigger = false;
//        }
//        else if (other.transform.tag == "SlotOut")
//        {
//            if (other.transform.childCount == 0)
//            {
//                Debug.Log("Collied with slot!(out)");
//            }
//        }
//    }


//    private void Update()
//    {
//        Vector2 Cursor = Input.mousePosition;
//        Cursor = Camera.main.ScreenToWorldPoint(Cursor);


//        if (MouseDown == true)
//        {
//            this.transform.position = Cursor;
//        }
//        else
//        {
//            if (trigger == true)
//            {
//                //this.GetComponent<SpriteRenderer>().enabled = false;
//            }

//            this.transform.localPosition = new Vector3(0, 0, 0);

//        }
//    }
    
//}