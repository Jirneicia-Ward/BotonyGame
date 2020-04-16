using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FlowerAtlus : MonoBehaviour
{
    public Flower[] flowers; //Holds flowers that can be selected

    public Flower findFlowerData(string genome)  //Find the data on a specific flower and return it 
    {
        switch (genome) //Based on passed in genome return the corrosponding flower.
        {
            case "RYBSS":             //Black
                return flowers[1];
            case "RYBSs":
                return flowers[2];
            case "RYBsS":
                return flowers[2];
            case "RYBss":
                return flowers[3];
            case "ryBSS":             //Blue
                return flowers[6];
            case "ryBSs":
                return flowers[4];
            case "ryBsS":
                return flowers[4];
            case "ryBss":
                return flowers[5];
            case "rYBSS":             //Green
                return flowers[9];
            case "rYBSs":
                return flowers[7];
            case "rYBsS":
                return flowers[7];
            case "rYBss":
                return flowers[8];
            case "RYbSS":             //Orange
                return flowers[12];
            case "RYbSs":
                return flowers[10];
            case "RYbsS":
                return flowers[10];
            case "RYbss":
                return flowers[11];
            case "RyBSS":            //Purple
                return flowers[15];
            case "RyBSs":
                return flowers[13];
            case "RyBsS":
                return flowers[13];
            case "RyBss":
                return flowers[14];
            case "RybSS":           //Red
                return flowers[18];
            case "RybSs":
                return flowers[16];
            case "RybsS":
                return flowers[16];
            case "Rybss":
                return flowers[17];
            case "rYbSS":           //Yellow
                return flowers[24];
            case "rYbSs":
                return flowers[22];
            case "rYbsS":
                return flowers[22];
            case "rYbss":
                return flowers[23];
            case "rybSS":            //White
                return flowers[21];
            case "rybSs":
                return flowers[19];
            case "rybsS":
                return flowers[19];
            case "rybss":
                return flowers[20];
            default:
                return flowers[0]; //Return Unknown
        }
    }
}
