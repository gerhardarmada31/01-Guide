using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class DisplayInventory : MonoBehaviour
{

    private bool isMenuOn;
    private Transform uiContainer;
    private GameObject continueButton;

    //del me
    private bool itemOn;

    public InventorySO inventory;

    [SerializeField] private int xStart;
    [SerializeField] private int yStart;
    public int x_spaceBetweenItem;
    public int y_spaceBetweenItem;
    public int numColomns;

    [Header("Parent of the content Items")]
    [SerializeField] private GameObject itemParent;
    [SerializeField] private GameObject statusParent;
    [SerializeField] private GameObject systemParent;


    public GameObject lastSelectedObj;
    private GameObject obj;

    public Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();
    [SerializeField] private List<GameObject> itemsList = new List<GameObject>();


    //PROP
    public List<GameObject> ItemsList
    {
        get { return itemsList; }
        set { itemsList = value; }
    }
    public Dictionary<InventorySlot, GameObject> ItemsDisplayed
    {
        get { return itemsDisplayed; }
        set { itemsDisplayed = value; }
    }

    private void Awake()
    {
        InitialDisplay();
    }

    void Start()
    {
        InventoryEvent.currentInventoryEvent.onInventoryUpdateUI += UpdateDisplay;
        OnOffInventory(false);

        foreach (var keyVal in itemsDisplayed)
        {
            Debug.Log("Key = " + keyVal.Key + "Val = " + keyVal.Value);
        }
    }

    public void InitialDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            var obj = Instantiate(inventory.Container[i].item.uiPrefab, Vector3.zero, Quaternion.identity, itemParent.transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            // obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            itemsDisplayed.Add(inventory.Container[i], obj);
        }


    }


    public Vector3 GetPosition(int i)
    {
        return new Vector3(xStart + (x_spaceBetweenItem * (i % numColomns)), yStart + ((-y_spaceBetweenItem * (i / numColomns))), 0f);
    }

    public void UpdateDisplay(bool _isAdd)
    {

        for (int i = 0; i < inventory.Container.Count; i++)
        {

            if (itemsDisplayed.ContainsKey(inventory.Container[i]))
            {

                // itemsDisplayed[inventory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");

                //Removes the item
                if (_isAdd == false)
                {
                    obj = Instantiate(inventory.Container[i].item.uiPrefab, Vector3.zero, Quaternion.identity, itemParent.transform);
                    obj.GetComponent<RectTransform>().localPosition = GetPosition(i);

                    Debug.Log("REMOVE ITEM! " + obj);

                }
            }
            else
            {
                //Adds the item
                if (_isAdd == true)
                {
                    obj = Instantiate(inventory.Container[i].item.uiPrefab, Vector3.zero, Quaternion.identity, itemParent.transform);
                    obj.GetComponent<RectTransform>().localPosition = GetPosition(i);

                    // obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
                    itemsDisplayed.Add(inventory.Container[i], obj);
                    // itemsList.Add(obj);
                }

            }
        }
    }

    //Its a UnityEvent the calls from the PlayerInput
    public void ItemTab()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(itemsDisplayed[inventory.Container[0]]);
    }

    public void DisplayOnOff()
    {

        isMenuOn = !isMenuOn;
        OnOffInventory(isMenuOn);

        // if (lastSelectedObj == null)
        // {
        //     EventSystem.current.SetSelectedGameObject(null);
        //     Debug.Log("default select invent");
        //     EventSystem.current.SetSelectedGameObject(itemsDisplayed[inventory.Container[0]]);
        // }
        // else if (isMenuOn == true)
        // {
        //     // EventSystem.current.SetSelectedGameObject(lastSelectedObj);
        // }

        // EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(itemsDisplayed[inventory.Container[0]]);
        // lastSelectedObj = EventSystem.current.currentSelectedGameObject;



        Debug.Log("Menu is" + isMenuOn);
    }

    //All of the objects inside the menu that turns
    public void OnOffInventory(bool _onOffSwitch)
    {

        //Something that activates only current tab
        foreach (Transform item in transform)
        {
            item.gameObject.SetActive(_onOffSwitch);
        }

        statusParent.SetActive(false);
        systemParent.SetActive(false);

    }

    //menu on only the last selected tab is activated.

}
