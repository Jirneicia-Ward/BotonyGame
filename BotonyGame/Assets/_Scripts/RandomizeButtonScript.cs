using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class RandomizeButtonScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject text; //Genome Text Area
    public GameObject sprite;        //Flower Spite Area
    public GameObject FlowerAtlus;   //Same as FLower Creator
    public GameObject flowerDescrption;  //Flower Description Area
    public GameObject unlockedFlowers;    //Holds script for unlocked flowers

    public delegate void ClickAction();           // Event 
    public static event ClickAction OnClicked;    // Event Variable that is subbed to and sent out.


    public void createPlant()
    {
        Flower flower;//Temp flower holder

        string genome = this.gameObject.GetComponent<RandomizerScript>().RandomGenome();  //Create Genome and store it
        text.GetComponent<TextMeshProUGUI>().text = genome;                            //Set text to Genome
        flower = FlowerAtlus.GetComponent<FlowerAtlus>().findFlowerData(genome); // Check if flower is right
        sprite.GetComponent<SpriteRenderer>().sprite = flower.flowerSprite;    //Set sprite to flower Sprite
        addFlowerToDiscovered(genome);          //Add flower to discovered list
        
    }

    public void addFlowerToDiscovered(string genome)  //Checks if flower has been discovered before and adds it to list if not
    {
        if (genome.Contains("sS") || genome.Contains("Ss"))   //Edit genome if medium stem to match flower object
        {
            genome = genome.Substring(0, 3) + "Ss or " + genome.Substring(0,3) + "sS";
        }
        if (!unlockedFlowers.GetComponent<FlowersUnlocked>().checkIfFlowerUnlocked(genome)) //If not unlocked yet add and send event
        {
            unlockedFlowers.GetComponent<FlowersUnlocked>().addFlowerToUnlocks(genome);
            OnClicked();    //Send out event notification
        }
    }
}
