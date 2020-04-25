using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryController : MonoBehaviour 
{
    //This idea of this class is to draw a raycast under the mouse to get if the object is over a slot and get data on the slot
    GraphicRaycaster graphicRaycaster; //Used to draw a raycast under the mouse
    PointerEventData pointerEventData; //Gets Pointer info
    List<RaycastResult> raycastResults; //List of all things raycast hits

    public GameObject UIManager; //Used to get the Canvas and screen based functions
    public GameObject Effects;

    GameObject draggedItem = null; //Item picked up
    GameObject PreviousSlot = null; //Slot item was dragged out of
    bool foundNewSlot = false; //True if item is dropped on into a new slot

    void Start()
    {
        graphicRaycaster = GameObject.Find("Canvas").GetComponent<GraphicRaycaster>(); // set variables
        pointerEventData = new PointerEventData(null);
        raycastResults = new List<RaycastResult>();
    }

    // Update is called once per frame
    void Update()
    {
        DragItems();
    }

    void DragItems()
    {
        if (Input.GetMouseButtonDown(0)) //If clicked
        {
            pointerEventData.position = Input.mousePosition; //Get pointer data
            graphicRaycaster.Raycast(pointerEventData, raycastResults); //Cast ray
            if(raycastResults.Count > 0) //If ray hit something
            {
                if (raycastResults[0].gameObject.GetComponent<flowerObjectScript>()) //If thing hit has flower script
                {
                    draggedItem = raycastResults[0].gameObject;   //Set dragged item
                    PreviousSlot = draggedItem.gameObject.transform.parent.gameObject;
                    draggedItem.transform.SetParent(UIManager.GetComponent<UIManager>().canvas.transform); //Take item out of previous slot
                }
            }
        }

        //Item follows mouse
        if(draggedItem != null)
        {
            draggedItem.GetComponent<RectTransform>().localPosition = UIManager.GetComponent<UIManager>().ScreenToCanvasPoint(Input.mousePosition);
        }

        //End Dragging
        if (Input.GetMouseButtonUp(0))
        {
            pointerEventData.position = Input.mousePosition;
            raycastResults.Clear();
            graphicRaycaster.Raycast(pointerEventData, raycastResults);//Cast Ray
            foundNewSlot = false;
            if(raycastResults.Count > 0) //If ray hit something
            {
                foreach(var result in raycastResults) //for each thing hit check if it is a slot
                {
                    if (result.gameObject.CompareTag("Slot") && result.gameObject.transform.childCount == 0) //If it is a slot and is empty
                    {
                        draggedItem.transform.SetParent(result.gameObject.transform); //Put item in slot
                        draggedItem.transform.localPosition = Vector3.zero;
                        Effects.GetComponent<BGEffectScript>().playSlotDrop();
                        foundNewSlot = true;
                        break;
                    }
                    if (result.gameObject.CompareTag("Trash")) //Delete if it is a trash can
                    {
                        Destroy(draggedItem);
                        Effects.GetComponent<BGEffectScript>().playTrash();
                    }
                }
            }
            if (!foundNewSlot) //If item is not dropped into a new slot put it in the previous slot
            {
                draggedItem.transform.SetParent(PreviousSlot.transform); //Put item in slot
                draggedItem.transform.localPosition = Vector3.zero;
                Effects.GetComponent<BGEffectScript>().playSlotDrop();
            }
            draggedItem = null;
        }//End of Drag
        raycastResults.Clear();
    }
}
