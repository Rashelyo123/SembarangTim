using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "ItemData")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public int efficiencyValue;
}
