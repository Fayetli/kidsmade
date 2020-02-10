using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IDropHandler
{
    public GameObject Case;

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

    public GameObject lastSlot;

    #region IdropHandler implementation
    public void OnDrop(PointerEventData eventData)
    {
            
        if (transform.gameObject.tag == "SlotIn" || transform.gameObject.tag == "FinishSlot")
        {
            if(DragHandler.itemBeingDragged.transform.parent.gameObject.tag == "FinishSlot" ||
                DragHandler.itemBeingDragged.transform.parent.gameObject.tag == "SlotIn") { }
            else if (transform.gameObject.GetComponent<ControllerScript>().canSet != false)
            {
                lastSlot = DragHandler.itemBeingDragged.transform.parent.gameObject;
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
                if(lastSlot.transform.childCount > 0)
                    lastSlot.transform.GetChild(0).gameObject.GetComponent<Image>().enabled = true;
                
                Case.transform.GetChild(1).gameObject.SetActive(false);
                Case.transform.GetChild(3).gameObject.SetActive(false);
                Case.transform.GetChild(5).gameObject.SetActive(false);


                if (DragHandler.itemBeingDragged.transform.tag == "1c")
                    Case.transform.GetChild(1).gameObject.SetActive(true);
                else if (DragHandler.itemBeingDragged.transform.tag == "2c")
                    Case.transform.GetChild(3).gameObject.SetActive(true);
                else if (DragHandler.itemBeingDragged.transform.tag == "3c")
                    Case.transform.GetChild(5).gameObject.SetActive(true);


                DragHandler.itemBeingDragged.GetComponent<Image>().enabled = false;
                
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
          
            }
            
        }
    }
    #endregion
}
