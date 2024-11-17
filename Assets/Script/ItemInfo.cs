using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemInfo : MonoBehaviour
{
    [SerializeField] public ItemData itemData;
    private GameObject TortillaText;
    private GameObject ToppingText;
    private GameObject SauceText;
    private BossButtle _bossButtle;

    void Start()
    {
        _bossButtle = GameObject.Find("BossCanvas").GetComponent<BossButtle>();
        TortillaText = GameObject.Find ("TortillaSelectText");
        ToppingText = GameObject.Find("ToppingSelectText");
        SauceText = GameObject.Find("SauceSelectText");
    }

    public void OnButton(){
        switch (itemData.itemType){
            case ItemType.Tortilla:
                TortillaText.GetComponent<TextMeshProUGUI>().text = itemData.Name;
                _bossButtle.GetData(itemData);
                break;
            case ItemType.Topping:
                ToppingText.GetComponent<TextMeshProUGUI>().text = itemData.Name;
                _bossButtle.GetData(itemData);
                break;
            case ItemType.Sauce:
                SauceText.GetComponent<TextMeshProUGUI>().text = itemData.Name;
                _bossButtle.GetData(itemData);
                break;
            default:
                break;
        }
    }

}
