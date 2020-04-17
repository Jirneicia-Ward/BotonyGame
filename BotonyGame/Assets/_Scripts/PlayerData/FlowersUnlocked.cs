using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowersUnlocked : MonoBehaviour
{
    private List<string> flowersUnlocked = new List<string>();  //List of flowers unlocked

    public bool checkIfFlowerUnlocked(string flower)          //Send in flower string to check if it is unlocked
    {
        for(int i = 0; i < flowersUnlocked.Count; i++)       //Loop thru list to check if it is in list
        {
            if (flower.Equals(flowersUnlocked[i]))
            {
                print("True");
                return true;     //If it is in list return true
            }
        }
        return false;            //If it is in list return false
    }

    public void addFlowerToUnlocks(string genome) //Allow external classes to add to flowers list
    {
        flowersUnlocked.Add(genome);
    }
}
