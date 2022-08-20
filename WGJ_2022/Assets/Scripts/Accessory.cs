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
public class Accessory : MonoBehaviour
{
    public AccessoryType type;
    public Sprite sprite;
}
