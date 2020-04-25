using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizerScript : MonoBehaviour
{
    public string RandomGenome()  //This function returns a randomized genome. It does this by looping five times and adding a letter to the end of the genome each time
    {
        string genome = ""; // Final product
        int currentRandomNumber;  //Temperary storage for random Int (0 = Cap | 1 = Lower)
        string cap = "";    //Stores the current cap letter
        string lower = "";  //Stores the current lower case letter

        for (int i = 0; i < 5; i++) 
        {
            currentRandomNumber = UnityEngine.Random.Range(0, 2);  //Create random in 0 thru 1. (0 = Cap | 1 = Lower)
            switch (i){   //Decide which letter of the genome is being decided
                case 0:  //Red
                    cap = "R";
                    lower = "r";
                    break;
                case 1:  //Yellow
                    cap = "Y";
                    lower = "y";
                    break;
                case 2:    //Blue
                    cap = "B";
                    lower = "b";
                    break;
                default:   //Stem accounts for spots three and four
                    cap = "S";
                    lower = "s";
                    break;
            }
            if (currentRandomNumber == 0)
            {
                genome += cap;
            }
            else
            {
                genome += lower;
            }
        }
        return genome;  //Return Final String Genome
    }

    public List<string> DuoRandomGenome()  //This function returns a random genome and it's counterpart.
    {
        string genome1 = ""; // Genome 1
        string genome2 = ""; // Counterpart
        List<string> genomes = new List<string>();
        int currentRandomNumber;  //Temperary storage for random Int (0 = Cap | 1 = Lower)
        string cap = "";    //Stores the current cap letter
        string lower = "";  //Stores the current lower case letter

        for (int i = 0; i < 5; i++)
        {
            currentRandomNumber = UnityEngine.Random.Range(0, 2);  //Create random in 0 thru 1. (0 = Cap | 1 = Lower)
            switch (i)
            {   //Decide which letter of the genome is being decided
                case 0:  //Red
                    cap = "R";
                    lower = "r";
                    break;
                case 1:  //Yellow
                    cap = "Y";
                    lower = "y";
                    break;
                case 2:    //Blue
                    cap = "B";
                    lower = "b";
                    break;
                default:   //Stem accounts for spots three and four
                    cap = "S";
                    lower = "s";
                    break;
            }
            if (currentRandomNumber == 0)
            {
                genome1 += cap;
                genome2 += lower;
            }
            else
            {
                genome1 += lower;
                genome2 += cap;
            }
        }
        genomes.Add(genome1);
        genomes.Add(genome2);
        return genomes;  //Return Final String Genome
    }
}
