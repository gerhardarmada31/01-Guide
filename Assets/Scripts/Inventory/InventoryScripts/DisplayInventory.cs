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

    public InventorySO inventory;
    [SerializeField] private int xStart;
    [SerializeField] private int yStart;

    public int x_spaceBetweenItem;
    public int y_spaceBetweenItem;
    public int numColomns;
    [SerializeField] private List<GameObject> itemsList = new List<GameObject>();
    public List<GameObject> ItemsList
    {
        get { return itemsList; }
        set { itemsList = value; }
    }
    public GameObject lastSelectedObj;
    private GameObject obj;
    public Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();
    public Dictionary<InventorySlot, GameObject> ItemsDisplayed
    {
        get { return itemsDisplayed; }
        set { itemsDisplayed = value; }
    }

    private void Awake()
    {
        InitialDisplay();
    }

    void TaskOnClick()
    {

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
            var obj = Instantiate(inventory.Container[i].item.uiPrefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            // obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            itemsDisplayed.Add(inventory.Container[i], obj);
            // itemsList.Add(obj);
            // itemsList.
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
                    obj = Instantiate(inventory.Container[i].item.uiPrefab, Vector3.zero, Quaternion.identity, transform);
                    obj.GetComponent<RectTransform>().localPosition = GetPosition(i);

                    Debug.Log("REMOVE ITEM! " + obj);
                    // itemsDisplayed.Remove(inventory.Container[i]);
                    // if()
                    // itemsList.Remove(obj);
                    // Destroy(obj);
                }
            }
            else
            {
                //Adds the item
                if (_isAdd == true)
                {
                    obj = Instantiate(inventory.Container[i].item.uiPrefab, Vector3.zero, Quaternion.identity, transform);
                    obj.GetComponent<RectTransform>().localPosition = GetPosition(i);

                    // obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
                    itemsDisplayed.Add(inventory.Container[i], obj);
                    // itemsList.Add(obj);
                }

            }
        }
    }

    public void DisplayOnOff()
    {

        isMenuOn = !isMenuOn;
        OnOffInventory(isMenuOn);

        if (lastSelectedObj == null)
        {
            EventSystem.current.SetSelectedGameObject(null);
            Debug.Log("default select invent");
            EventSystem.current.SetSelectedGameObject(itemsDisplayed[inventory.Container[0]]);
        }
        else if (isMenuOn == true)
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(lastSelectedObj);
        }

        lastSelectedObj = EventSystem.current.currentSelectedGameObject;


        Debug.Log("Menu is" + isMenuOn);
    }

    public void OnOffInventory(bool _onOffSwitch)
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            gameObject.transform.GetChild(i).gameObject.SetActive(_onOffSwitch);
        }
    }
}
