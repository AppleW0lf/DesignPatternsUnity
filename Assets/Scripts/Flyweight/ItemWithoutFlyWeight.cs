using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemWithoutFlyWeight : MonoBehaviour
{
    public Guid id = Guid.NewGuid();
    public List<LocalizedString> localizedName;
    public List<LocalizedString> localizedDescription;
    public int maxStackCount;
    public int currentStackCount;
    public float weight;
    public ItemType type;
    public float maxDurability;
    public float currentDurability;
    public bool isStackable;
    public bool isFlammable;
}