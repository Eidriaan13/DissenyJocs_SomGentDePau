using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    public bool consumigRemovesIt = true;
    public int maxQuantity = 99;
    public int actualQuantity = 0;

    public Sprite displayImage;
    public string displayName;
}
