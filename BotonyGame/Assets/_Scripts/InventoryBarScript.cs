using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryBarScript : MonoBehaviour, IDropHandler
{
    public int numberOfHeldFlowers = 0;
    public GameObject[] slots;
    
    public void OnDrop(PointerEventData eventData)
    {
        numberOfHeldFlowers++;
        print(numberOfHeldFlowers);
        this.gameObject.GetComponent<AudioSource>().Play();   
    }

}
