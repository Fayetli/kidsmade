using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    public GameObject var_1_c;
    public GameObject var_1_d;
    public GameObject var_2_c;
    public GameObject var_2_d;
    public GameObject var_3_c;
    public GameObject var_3_d;

    public GameObject item
    {
        get
        {
            if(transform.childCount > 0)
            {
                return transform.GetChild(0).gameObject;
            }
            return null;
        }
    }

    #region IdropHandler implementation
    public void OnDrop(PointerEventData eventData)
    {
            /*GetComponent<ControllerScript>().canSet != false &&
            DragHandler.itemBeingDragged.transform.parent.tag != "SlotIn")*/
        if (transform.gameObject.tag == "SlotIn" || transform.gameObject.tag == "FinishSlot")
        {
            if(DragHandler.itemBeingDragged.transform.parent.gameObject.tag == "FinishSlot" ||
                DragHandler.itemBeingDragged.transform.parent.gameObject.tag == "SlotIn") { }
            else if (transform.gameObject.GetComponent<ControllerScript>().canSet != false)
            {
                if (!item && DragHandler.itemBeingDragged.transform.parent.gameObject.tag != "SlotIn" &&
                    DragHandler.itemBeingDragged.transform.parent.gameObject.tag != "FinishSlot")
                {
                    DragHandler.itemBeingDragged.transform.SetParent(transform);
                }
                else
                {
                    Transform aux = DragHandler.itemBeingDragged.transform.parent;
                    DragHandler.itemBeingDragged.transform.SetParent(transform);
                    item.transform.SetParent(aux);
                }

                var_1_d.gameObject.SetActive(false);
                var_2_d.gameObject.SetActive(false);
                var_3_d.gameObject.SetActive(false);


                if (DragHandler.itemBeingDragged.transform.tag == "1c")
                    var_1_d.gameObject.SetActive(true);
                else if (DragHandler.itemBeingDragged.transform.tag == "2c")
                    var_2_d.gameObject.SetActive(true);
                else if (DragHandler.itemBeingDragged.transform.tag == "3c")
                    var_3_d.gameObject.SetActive(true);
                //DragHandler.itemBeingDragged.SetActive(false);
            }
            else if(DragHandler.itemBeingDragged.transform.parent.gameObject.tag == "SlotIn" ||
                DragHandler.itemBeingDragged.transform.parent.gameObject.tag == "FinishSlot")
            {
                if (!item)
                {
                    DragHandler.itemBeingDragged.transform.SetParent(transform);
                }
                else
                {
                    Transform aux = DragHandler.itemBeingDragged.transform.parent;
                    DragHandler.itemBeingDragged.transform.SetParent(transform);
                    item.transform.SetParent(aux);
                }
                //DragHandler.itemBeingDragged.SetActive(true);
            }
            //else if()
        }
    }
    #endregion
}
