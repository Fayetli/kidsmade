using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotInScript : MonoBehaviour
{
    public GameObject button = null;
    public bool CanUse = true;

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<DragHandler2>().MouseDown == false)
        {
            Debug.Log("Slot trigg");

            if(!button.gameObject.activeInHierarchy)
                button.gameObject.SetActive(true);
        }
    }

}
