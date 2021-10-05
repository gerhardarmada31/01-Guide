using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
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
    public GameObject lastSelectedObj;
    private GameObject obj;
    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();


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
    }

    public void InitialDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            var obj = Instantiate(inventory.Container[i].item.uiPrefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            // obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            itemsDisplayed.Add(inventory.Container[i], obj);
            itemsList.Add(obj);
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
                Debug.Log("asdasdas");
                // itemsDisplayed[inventory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");

                if (_isAdd == false)
                {
                    itemsDisplayed.Remove(inventory.Container[i]);
                    Destroy(obj);
                }
            }
            else
            {
                if (_isAdd == true)
                {

                    obj = Instantiate(inventory.Container[i].item.uiPrefab, Vector3.zero, Quaternion.identity, transform);
                    obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                    // obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
                    itemsDisplayed.Add(inventory.Container[i], obj);
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
            EventSystem.current.SetSelectedGameObject(itemsList[0]);
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
