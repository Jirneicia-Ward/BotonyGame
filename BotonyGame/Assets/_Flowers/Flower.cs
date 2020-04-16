using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Botany/Flower")]
public class Flower : ScriptableObject
{
    public string genome;
    public string flowerName;
    public Sprite flowerSprite;
    [TextArea]
    public string flowerDescription;
}