using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDropScript : MonoBehaviour, IPointerDownHandler, IEndDragHandler, IBeginDragHandler, IDragHandler
{
    private RectTransform rectTransform;  //The location of this image
    [SerializeField] private Canvas canvas;  //The Cancas this image is on
    private CanvasGroup canvasGroup;        //The canvas group controls alpha and raycasting

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();  //Get parts
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)  //On Begin Drag allow for other objects to detect this object being dropped on them and lower alpha
    {
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = .6f;
    }

    public void OnDrag(PointerEventData eventData)  //Change image position based on mouse change
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor; //change position to where it is dragged to.
    }

    public void OnEndDrag(PointerEventData eventData)  //Stop allowing other objects from detecting if this has been dropped onto them.
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }
}
