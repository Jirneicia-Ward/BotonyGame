using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class flowerObjectScript : MonoBehaviour
{
    public Flower flower;
    public string genome = "RYBSS";
    // Start is called before the first frame update
    void Start()
    {
        updateFlowerDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void updateFlowerDisplay()
    {
        this.gameObject.GetComponent<Image>().sprite = flower.flowerSprite;
    }
}
