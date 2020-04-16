using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class RandomizeButtonScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject text;
    public GameObject FlowerCreator;
    public GameObject sprite;
    public GameObject FlowerAtlus;
    public GameObject flowerDescrption;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void createPlant()
    {
        Flower flower;

        string genome = FlowerCreator.GetComponent<RandomizerScript>().RandomGenome();
        text.GetComponent<TextMeshProUGUI>().text = genome;
        flower = FlowerAtlus.GetComponent<FlowerAtlus>().findFlowerData(genome); // Check if flower is right
        sprite.GetComponent<SpriteRenderer>().sprite = flower.flowerSprite;
        
    }
}
