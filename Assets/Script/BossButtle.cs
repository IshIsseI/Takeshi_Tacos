using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class BossButtle : MonoBehaviour
{

    public Takeshi _takeshi;
    public PlayerManager _playerManager;
    private List<ItemData> _items;
    public GameObject TortillaContent;
    public GameObject ToppingContent;
    public GameObject SauceContent;
    public GameObject ItemPrefab;
    public GameObject PlayerPanel;
    public GameObject SelectPanel;
    private ItemData TortillaData;
    private ItemData ToppingData;
    private ItemData SauceData;
    public GameObject TortillaText;
    public GameObject ToppingText;
    public GameObject SauceText;
    public ItemData CompletTortillaData;
    public ItemData CompletToppingData;
    public ItemData CompletSauceData;

    void Start()
    {
        //gameObject.SetActive(false);
        SelectPanel.SetActive(false);
        //PlayerPanel.SetActive(false);
    }

    public void BossButtleStart()
    {
        gameObject.SetActive(true);
        PlayerPanel.SetActive(true);
    }

    public void OnEscapeButton()
    {
        gameObject.SetActive(false);
        Takeshi.CanMove = true;
        _takeshi.Escape();
    }

    public void OnCheckButton()
    {
        SelectPanel.SetActive(true);
        TortillaText.GetComponent<TextMeshProUGUI>().text = "";
        ToppingText.GetComponent<TextMeshProUGUI>().text = "";
        SauceText.GetComponent<TextMeshProUGUI>().text = "";
        foreach (Transform child in TortillaContent.transform) { Destroy(child.gameObject); }
        foreach (Transform child in ToppingContent.transform) { Destroy(child.gameObject); }
        foreach (Transform child in SauceContent.transform) { Destroy(child.gameObject); }
        _items = _playerManager.GetItemData();
        foreach (var item in _items)
        {
            var obj = Instantiate(ItemPrefab);
            obj.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = item.Name;
            obj.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "x" + item.count;
            obj.transform.GetChild(2).GetComponent<ItemInfo>().itemData = item;

            if (item.itemType == ItemType.Tortilla)
            {
                obj.transform.SetParent(TortillaContent.transform, false);
            }
            else if (item.itemType == ItemType.Topping)
            {
                obj.transform.SetParent(ToppingContent.transform, false);
            }
            else
            {
                obj.transform.SetParent(SauceContent.transform, false);
            }
        }
    }

    public void OnBuckButton()
    {
        SelectPanel.SetActive(false);
    }

    public void OnFoodSelectButton()
    {
        if(TortillaData != null && ToppingData != null && SauceData != null){
            Debug.Log(TortillaData.Name + "/" + ToppingData.Name + "/" + SauceData.Name);
            if(CompletTortillaData.ID == TortillaData.ID && CompletToppingData.ID == ToppingData.ID && CompletSauceData.ID == SauceData.ID)
            {
                Debug.Log("ゲームクリア");
                GameCompleted();
            }else {
                Debug.Log("素材が違うよ");
            }
        }else{
            Debug.Log("素材が足りないよ");
        }
    }

    public void GetData(ItemData newItem){
        switch(newItem.itemType){
            case ItemType.Tortilla:
                TortillaData = newItem;
                break;
            case ItemType.Topping:
                ToppingData = newItem;
                break;
            case ItemType.Sauce:
                SauceData = newItem;
                break;
        }
    }

    public void GameCompleted(){

    }
}
