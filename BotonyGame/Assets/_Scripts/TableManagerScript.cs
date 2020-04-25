using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableManagerScript : MonoBehaviour
{
    public GameObject flowerAtlus; //Used to find flower based on genome
    public GameObject[] resultingFlowersSlots; //All slots that are used to display possible Flowers
    public GameObject effectController;

    List<string> flowerArray; //2 Genomes of starting flowers
    List<string> finalFlowerArray; //Genomes of all resulting flowers
    List<Flower> flowerObjectArray; //Flower objects of all resulting flowers
    public GameObject InstantiableFlower; //Use to create new flower based on new flower

    public GameObject CreationSlot; //Used to put new flower in a slot

    public void buttonTest()
    {
        flowerArray = gameObject.GetComponent<RandomizerScript>().DuoRandomGenome(); //Get two starting flowers
        finalFlowerArray = CreateResultingFlowerArray(flowerArray[0], flowerArray[1]);  //Find all resulting flowers;
        flowerObjectArray = FindAllFlowers(finalFlowerArray);                           // Find all resulting flower objects
        UpdateTable(flowerObjectArray);
        StartCoroutine(SelectNewFlower());
    }

    public List<string> CreateResultingFlowerArray(string genome1, string genome2)  //Use this function by passing in two flowers and returning the resulting array of possible flowers.
    {
        List<string> resultingFlowers = new List<string>();

        char[] genome1Chars = genome1.ToCharArray(); //Create array out of genome 1
        char[] genome2Chars = genome2.ToCharArray(); //Create array out of genome 2

        resultingFlowers.Add(new string(new char[] { genome1Chars[0], genome1Chars[1], genome1Chars[2], genome1Chars[3], genome1Chars[4]}));  // 11111  //Loop with 1 sub
        resultingFlowers.Add(new string(new char[] { genome2Chars[0], genome1Chars[1], genome1Chars[2], genome1Chars[3], genome1Chars[4] })); // 21111
        resultingFlowers.Add(new string(new char[] { genome1Chars[0], genome2Chars[1], genome1Chars[2], genome1Chars[3], genome1Chars[4] })); // 12111
        resultingFlowers.Add(new string(new char[] { genome1Chars[0], genome1Chars[1], genome2Chars[2], genome1Chars[3], genome1Chars[4] })); // 11211
        resultingFlowers.Add(new string(new char[] { genome1Chars[0], genome1Chars[1], genome1Chars[2], genome2Chars[3], genome1Chars[4] })); // 11121
        resultingFlowers.Add(new string(new char[] { genome1Chars[0], genome1Chars[1], genome1Chars[2], genome1Chars[3], genome2Chars[4] })); // 11112

        resultingFlowers.Add(new string(new char[] { genome2Chars[0], genome2Chars[1], genome1Chars[2], genome1Chars[3], genome1Chars[4] })); // 22111  //Loop with 2 subs
        resultingFlowers.Add(new string(new char[] { genome2Chars[0], genome1Chars[1], genome2Chars[2], genome1Chars[3], genome1Chars[4] })); // 21211
        resultingFlowers.Add(new string(new char[] { genome2Chars[0], genome1Chars[1], genome1Chars[2], genome2Chars[3], genome1Chars[4] })); // 21121
        resultingFlowers.Add(new string(new char[] { genome2Chars[0], genome1Chars[1], genome1Chars[2], genome1Chars[3], genome2Chars[4] })); // 21112
        resultingFlowers.Add(new string(new char[] { genome1Chars[0], genome2Chars[1], genome2Chars[2], genome1Chars[3], genome1Chars[4] })); // 12211
        resultingFlowers.Add(new string(new char[] { genome1Chars[0], genome2Chars[1], genome1Chars[2], genome2Chars[3], genome1Chars[4] })); // 12121
        resultingFlowers.Add(new string(new char[] { genome1Chars[0], genome2Chars[1], genome1Chars[2], genome1Chars[3], genome2Chars[4] })); // 12112
        resultingFlowers.Add(new string(new char[] { genome1Chars[0], genome1Chars[1], genome2Chars[2], genome2Chars[3], genome1Chars[4] })); // 11221
        resultingFlowers.Add(new string(new char[] { genome1Chars[0], genome1Chars[1], genome2Chars[2], genome1Chars[3], genome2Chars[4] })); // 11212
        resultingFlowers.Add(new string(new char[] { genome1Chars[0], genome1Chars[1], genome1Chars[2], genome2Chars[3], genome2Chars[4] })); // 11122

        resultingFlowers.Add(new string(new char[] { genome2Chars[0], genome2Chars[1], genome2Chars[2], genome1Chars[3], genome1Chars[4] })); // 22211  //Loop with 3 subs
        resultingFlowers.Add(new string(new char[] { genome2Chars[0], genome2Chars[1], genome1Chars[2], genome2Chars[3], genome1Chars[4] })); // 22121
        resultingFlowers.Add(new string(new char[] { genome2Chars[0], genome2Chars[1], genome1Chars[2], genome1Chars[3], genome2Chars[4] })); // 22112
        resultingFlowers.Add(new string(new char[] { genome2Chars[0], genome1Chars[1], genome2Chars[2], genome2Chars[3], genome1Chars[4] })); // 21221
        resultingFlowers.Add(new string(new char[] { genome2Chars[0], genome1Chars[1], genome2Chars[2], genome1Chars[3], genome2Chars[4] })); // 21212
        resultingFlowers.Add(new string(new char[] { genome2Chars[0], genome1Chars[1], genome1Chars[2], genome2Chars[3], genome2Chars[4] })); // 21122
        resultingFlowers.Add(new string(new char[] { genome1Chars[0], genome2Chars[1], genome2Chars[2], genome2Chars[3], genome1Chars[4] })); // 12221
        resultingFlowers.Add(new string(new char[] { genome1Chars[0], genome2Chars[1], genome2Chars[2], genome1Chars[3], genome2Chars[4] })); // 12212
        resultingFlowers.Add(new string(new char[] { genome1Chars[0], genome2Chars[1], genome1Chars[2], genome2Chars[3], genome2Chars[4] })); // 12122
        resultingFlowers.Add(new string(new char[] { genome1Chars[0], genome1Chars[1], genome2Chars[2], genome2Chars[3], genome2Chars[4] })); // 11222

        resultingFlowers.Add(new string(new char[] { genome2Chars[0], genome2Chars[1], genome2Chars[2], genome2Chars[3], genome1Chars[4] })); // 22221  //Loop with 4 subs
        resultingFlowers.Add(new string(new char[] { genome2Chars[0], genome1Chars[1], genome2Chars[2], genome2Chars[3], genome2Chars[4] })); // 21222
        resultingFlowers.Add(new string(new char[] { genome2Chars[0], genome2Chars[1], genome1Chars[2], genome2Chars[3], genome2Chars[4] })); // 22122
        resultingFlowers.Add(new string(new char[] { genome2Chars[0], genome2Chars[1], genome2Chars[2], genome1Chars[3], genome2Chars[4] })); // 22212
        resultingFlowers.Add(new string(new char[] { genome1Chars[0], genome2Chars[1], genome2Chars[2], genome2Chars[3], genome2Chars[4] })); // 12222

        resultingFlowers.Add(new string(new char[] { genome2Chars[0], genome2Chars[1], genome2Chars[2], genome2Chars[3], genome2Chars[4] })); // 22222 / Sub all

        return resultingFlowers;

    }

    public List<Flower> FindAllFlowers(List<string> flowers)
    {
        List<Flower> allFlowers = new List<Flower>();
        for(int i = 0; i < flowers.Count; i++)
        {
            allFlowers.Add(flowerAtlus.GetComponent<FlowerAtlus>().findFlowerData(flowers[i]));
        }
        return allFlowers;
    }

    public void UpdateTable(List<Flower> flowers) //Use this function to update all the slots in the table based on the passed in array
    {
        for (int i = 0; i < resultingFlowersSlots.Length; i++)
        {
            resultingFlowersSlots[i].GetComponent<flowerObjectScript>().flower = flowers[i];
            resultingFlowersSlots[i].GetComponent<flowerObjectScript>().updateFlowerDisplay();
        }
    }

    IEnumerator SelectNewFlower() //Use this method to loop thru all possible flowers and select the new flower
    {
        int currentRandomNumber = UnityEngine.Random.Range(0,33); //Select stopping point of search
        int numberOfLoops = UnityEngine.Random.Range(0, 2); //Number of times to loop thru fully.

        for (int j = 0; j < numberOfLoops; j++) //Number of times to loop fully
        {
            for (int i = 0; i < 32; i++) //Looping thru once
            {
                effectController.GetComponent<BGEffectScript>().playClick();
                resultingFlowersSlots[i].GetComponent<CanvasGroup>().alpha = 0.5f;
                yield return new WaitForSecondsRealtime(0.05f);
                resultingFlowersSlots[i].GetComponent<CanvasGroup>().alpha = 1f;
            }
        }

        for (int i = 0; i < currentRandomNumber; i++) //Loop thru to select final new flower
        {
            effectController.GetComponent<BGEffectScript>().playClick();
            resultingFlowersSlots[i].GetComponent<CanvasGroup>().alpha = 0.5f;
            yield return new WaitForSecondsRealtime(0.05f);
            resultingFlowersSlots[i].GetComponent<CanvasGroup>().alpha = 1f;
        }
        effectController.GetComponent<BGEffectScript>().playSuccess(); //Play sound effect

        GameObject newFlower = Instantiate(InstantiableFlower); //Create new flower
        newFlower.transform.SetParent(CreationSlot.transform, false);
        newFlower.transform.localPosition = Vector3.zero;
        newFlower.GetComponent<flowerObjectScript>().genome = finalFlowerArray[currentRandomNumber];  //Set genome
        newFlower.GetComponent<flowerObjectScript>().flower = flowerObjectArray[currentRandomNumber]; //Set Flower
        newFlower.GetComponent<flowerObjectScript>().updateFlowerDisplay(); //Update sprite

        for (int i = 0; i < 3; i++) //Blink final selection for flair
        {
            resultingFlowersSlots[currentRandomNumber].GetComponent<CanvasGroup>().alpha = 0f;
            yield return new WaitForSecondsRealtime(0.2f);
            resultingFlowersSlots[currentRandomNumber].GetComponent<CanvasGroup>().alpha = 1f;
            yield return new WaitForSecondsRealtime(0.2f);
        }
    }
}
