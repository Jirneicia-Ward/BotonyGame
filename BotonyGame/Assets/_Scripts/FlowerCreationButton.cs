using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class FlowerCreationButton : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject text; //Genome Text Area
    public GameObject FlowerCreator;  //Game object with script for for Flower Atlus and Randomizer 
    public GameObject sprite;        //Flower Spite Area
    public GameObject FlowerAtlus;   //Same as FLower Creator
    public GameObject flowerDescrption;  //Flower Description Area
    public GameObject InstatiatableFlower;

    public void createPlant()
    {
        Flower flower;//Temp flower holder

        string genome = this.gameObject.GetComponent<RandomizerScript>().RandomGenome();  //Create Genome and store it
        print(genome);
        text.GetComponent<TextMeshProUGUI>().text = genome;                            //Set text to Genome
        flower = FlowerAtlus.GetComponent<FlowerAtlus>().findFlowerData(genome); // Check if flower is right
        sprite.GetComponent<SpriteRenderer>().sprite = flower.flowerSprite;    //Set sprite to flower Sprite
        GameObject newFlower = Instantiate(InstatiatableFlower);
        newFlower.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        newFlower.GetComponent<DragDropScript>().canvas = GameObject.FindGameObjectsWithTag("Canvas")[0].GetComponent<Canvas>();
        newFlower.GetComponent<flowerObjectScript>().flower = flower;
        newFlower.GetComponent<flowerObjectScript>().updateFlowerDisplay();
        addFlowerToDiscovered(genome);          //Add flower to discovered list
        
    }

    public void addFlowerToDiscovered(string genome)  //Checks if flower has been discovered before and adds it to list if not
    {
        if (genome.Contains("sS") || genome.Contains("Ss"))   //Edit genome if medium stem to match flower object
        {
            genome = genome.Substring(0, 3) + "Ss or " + genome.Substring(0,3) + "sS";
        }
        if (!FlowerCreator.GetComponent<FlowersUnlocked>().checkIfFlowerUnlocked(genome)) //If not unlocked yet add and send event
        {
            FlowerCreator.GetComponent<FlowersUnlocked>().addFlowerToUnlocks(genome);
        }
    }
}
