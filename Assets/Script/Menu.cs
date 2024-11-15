using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class Menu : MonoBehaviour
{
    public GameObject HomeMenu;
    public GameObject ItemMenu;
    public GameObject SkillMenu;
    public GameObject HomeButton;
    public GameObject ItemButton;
    public GameObject SkillButton;

    public PlayerManager _playerManager;
    private List<ItemData> _items;

    public GameObject TortillaContent;
    public GameObject ToppingContent;
    public GameObject SauceContent;
    public GameObject ItemPrefab;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.SetActive(false);
        HomeMenu.SetActive(true);
        ItemMenu.SetActive(false);
        SkillMenu.SetActive(false);
        HomeButton.GetComponent<Button>().Select();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void OnHomeButton()
    {
        ClosePanel();
        HomeMenu.SetActive(true);
    }
    public void OnItemButton()
    {
        foreach (Transform child in TortillaContent.transform) { Destroy(child.gameObject); }
        foreach (Transform child in ToppingContent.transform) { Destroy(child.gameObject); }
        foreach (Transform child in SauceContent.transform) { Destroy(child.gameObject); }
        _items = _playerManager.GetItemData();
        foreach (var item in _items)
        {
            var obj = Instantiate(ItemPrefab);
            obj.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = item.Name;
            obj.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "x" + item.count;

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
        ClosePanel();
        ItemMenu.SetActive(true);
    }
    public void OnSkillButton()
    {
        ClosePanel();
        SkillMenu.SetActive(true);
    }

    void ClosePanel()
    {
        HomeMenu.SetActive(false);
        ItemMenu.SetActive(false);
        SkillMenu.SetActive(false);
    }
}
