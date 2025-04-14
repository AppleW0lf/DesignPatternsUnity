using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item Data", menuName = "Scriptable Objects/Item Data")]
public class ItemSO : ScriptableObject
{
    [field: SerializeField] public int id { get; private set; }
    [field: SerializeField] public List<LocalizedString> localizedName { get; private set; }
    [field: SerializeField] public List<LocalizedString> localizedDescription { get; private set; }
    [field: SerializeField] public int maxStackCount { get; private set; }
    [field: SerializeField] public float weight { get; private set; }
    [field: SerializeField] public ItemType type { get; private set; }
    [field: SerializeField] public float maxDurability { get; private set; }
    [field: SerializeField] public bool isStackable { get; private set; }
    [field: SerializeField] public bool isFlammable { get; private set; }
}