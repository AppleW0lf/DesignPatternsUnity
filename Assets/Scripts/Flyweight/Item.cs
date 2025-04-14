using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    /* public int id;
     public List<LocalizedString> localizedName;
     public List<LocalizedString> localizedDescription;
     public int maxStackCount;
     public int currentStackCount;
     public float weight;
     public ItemType type;
     public float maxDurability;
     public float currentDurability;
     public bool isStackable;
     public bool isFlammable;*/
    public ItemSO itemData;
    public int currentStackCount;
    public float currentDurability;
}

[System.Serializable]
public class LocalizedString
{
    public string value;
    public Language language;
}

public enum Language
{ English, Russian }

public enum ItemType
{ Resource, Equipable }