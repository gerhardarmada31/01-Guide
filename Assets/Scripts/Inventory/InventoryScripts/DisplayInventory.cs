using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
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
    private List<GameObject> itemsList = new List<GameObject>();
    public GameObject lastSelectedObj;
    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();
    // Start is called before the first frame update

    private void Awake()
    {
        continueButton = EventSystem.current.firstSelectedGameObject;
        // EventSystem.current.firstSelectedGameObject = null;

        if (itemsList != null)
        {
            EventSystem.current.SetSelectedGameObject(lastSelectedObj);
        }
        Debug.Log("yoasdasdasd  " + EventSystem.current.currentSelectedGameObject);


        uiContainer = GetComponentInChildren<Transform>();
        uiContainer.gameObject.SetActive(false);
    }

    void Start()
    {

        CreateDisplay();
    }

    public void CreateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            // obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            itemsDisplayed.Add(inventory.Container[i], obj);
            itemsList.Add(obj);
        }
        EventSystem.current.SetSelectedGameObject(itemsList[0]);
        //EventSystem.current.firstSelectedGameObject = inventory.Container[1].item.prefab;
    }

    // private void OnDisable()
    // {
    //     lastSelectedObj = EventSystem.current.currentSelectedGameObject;
    // }

    public Vector3 GetPosition(int i)
    {
        return new Vector3(xStart + (x_spaceBetweenItem * (i % numColomns)), yStart + ((-y_spaceBetweenItem * (i / numColomns))), 0f);
    }

    public void UpdateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            if (itemsDisplayed.ContainsKey(inventory.Container[i]))
            {
                return;
                // itemsDisplayed[inventory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            }
            else
            {
                var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                // obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
                itemsDisplayed.Add(inventory.Container[i], obj);
            }
        }
    }

    public void DisplayOnOff()
    {
        isMenuOn = !isMenuOn;
        uiContainer.gameObject.SetActive(isMenuOn);
        Debug.Log("Menu is" + isMenuOn);

        // if (isMenuOn==true)
        // {
        //     uiContainer.gameObject.SetActive(true);
        // }
        // else
        // {
        //     uiContainer.gameObject.SetActive(false);
        // }
    }
}
