using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject itemBeingDragged;
    Vector3 startPosition;
    Transform startParent;

    float scaleX;
    float scaleZ;

    #region IBeginDragHandler implementation
    public void OnBeginDrag(PointerEventData eventData)
    {
        itemBeingDragged = gameObject;
        startPosition = transform.position;
        startParent = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;

    }

    #endregion

    #region IDragHandler implementation

    public void OnDrag(PointerEventData eventData)
    {
        if (itemBeingDragged.transform.parent.gameObject.tag != "SlotIn" &&
            itemBeingDragged.transform.parent.gameObject.tag != "FinishSlot")
        {
            transform.position = Input.mousePosition;
        }
    }

    #endregion

    #region IEndDragHandler implementaion
    public void OnEndDrag(PointerEventData eventData)
    {

        
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        if (transform.parent == startParent)
        {
            transform.position = startPosition;
        }
        itemBeingDragged = null;
    }

    #endregion
}
