using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemData
{
    public string ID;
    public string Name;
}

[CreateAssetMenu(fileName = "ItemSetting", menuName = "Scriptable Objects/ItemSetting")]
public class ItemSetting : ScriptableObject
{
    public List<ItemData> Tortilla;
    public List<ItemData> Topping;
    public List<ItemData> Sauce;
}
