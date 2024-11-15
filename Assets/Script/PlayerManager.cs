using System.Collections.Generic;
using UnityEngine;

//プレイヤーを管理
public class PlayerManager : MonoBehaviour
{
    [SerializeField] private List<ItemData> _itemDataList = new List<ItemData>();   //プレイヤーの所持アイテム

    //アイテムを取得
    public void CountItem(string itemId, string itemName, ItemType itemType, int count)
    {
        // IDが一致するアイテムがあるか検索
        bool itemFound = false;

        for (int i = 0; i < _itemDataList.Count; i++)
        {
            if (_itemDataList[i].ID == itemId)
            {
                // IDが一致した場合、カウントを増加
                _itemDataList[i].CountUp(count);
                itemFound = true;
                break;
            }
        }

        // IDが一致しなければ新しいアイテムを追加
        if (!itemFound)
        {
            ItemData itemData = new ItemData(itemId, itemName, itemType, count);
            _itemDataList.Add(itemData);
        }
    }

    //アイテムを使用
    public void UseItem(string itemId, int count)
    {
        //List内を検索
        for (int i = 0; i < _itemDataList.Count; i++)
        {
            //IDが一致していたらカウント
            if (_itemDataList[i].ID == itemId)
            {
                //アイテムをカウントダウン
                _itemDataList[i].CountDown(count);
                break;
            }
        }
    }

    public List<ItemData> GetItemData()
    {
        return _itemDataList;
    }
}