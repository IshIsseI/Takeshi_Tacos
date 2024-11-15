using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public enum ItemType{
    Tortilla,
    Topping,
    Sauce
}

[Serializable]
public class ItemData
{
    public string ID;
    public string Name;
    public ItemType itemType;
    public int count;


    public ItemData(string ID, string Name, ItemType itemType, int count)
    {
        this.ID = ID;
        this.Name = Name;
        this.itemType = itemType;
        this.count = count;
    }

    //所持数カウントアップ
    public void CountUp(int value = 1)
    {
        count += value;
    }

    //所持数カウントダウン
    public void CountDown(int value = 1)
    {
        count -= value;
    }
}

[CreateAssetMenu(fileName = "ItemSetting", menuName = "Scriptable Objects/ItemSetting")]
public class ItemSetting : ScriptableObject
{
    public List<ItemData> Tortilla;
    public List<ItemData> Topping;
    public List<ItemData> Sauce;

    public ItemData RandomItem(int max){
        int rnd = UnityEngine.Random.Range(1, 3);
        switch(rnd){
            case 1:
                return Tortilla[UnityEngine.Random.Range(0, max)];
            case 2:
                return Topping[UnityEngine.Random.Range(0, max)];
            case 3:
                return Sauce[UnityEngine.Random.Range(0, max)];
            default:
                return null;
        }
    }
}
