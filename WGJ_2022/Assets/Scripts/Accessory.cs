using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AccessoryType
{
    Leaf,
    Saw,
    TopHat,
    Glasses,
    BunnyEars,
    Glasses3D,
    CowboyHat,
    Headband,
    DuctTape,
    PartyHat,
    Veil,
    ChristmasCap
}

[CreateAssetMenu(fileName = "Accessory", menuName = "Accessory", order = 0)]
public class Accessory : ScriptableObject
{
    public AccessoryType type;
    public Sprite sprite;
    public Sprite backSprite;
    public Sprite objectSprite;
}
