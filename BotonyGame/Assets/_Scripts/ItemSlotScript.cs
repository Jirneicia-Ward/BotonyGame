using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlotScript : MonoBehaviour, IDropHandler
{

    public void OnDrop(PointerEventData eventData)  //This function centers an item dropped into the item slot
    {
        if (eventData.pointerDrag != null) //Check if the drop left an item
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition; //Set dropped items position to this postion
        }
    }
}
