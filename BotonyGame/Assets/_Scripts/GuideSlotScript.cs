using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GuideSlotScript : MonoBehaviour
{
    public Flower flower;
    private bool isDiscovered = false;
    public GameObject FlowerData;

    void OnEnable()
    {
        RandomizeButtonScript.OnClicked += displayFlower;   //Sub to event
    }

    void OnDisable()
    {
        RandomizeButtonScript.OnClicked -= displayFlower; //Desub from event
    }

    private void OnMouseEnter()
    {
        print("F");
        this.gameObject.GetComponent<CanvasGroup>().alpha = .6f;
    }

    private void OnMouseExit()
    {
        this.gameObject.GetComponent<CanvasGroup>().alpha = 1f;
    }

    public void Start()
    {
        displayFlower();  //Check if flower is already unlocked
    }

    public void displayFlower()  //Change flower sprite if unlocked
    {
        if (FlowerData.GetComponent<FlowersUnlocked>().checkIfFlowerUnlocked(flower.genome))  //Check if flower is unlocked
        {
            isDiscovered = true; //set is discovered to true
            this.gameObject.GetComponent<Image>().sprite = flower.flowerSprite;  //Change sprite
        }
    }
}
