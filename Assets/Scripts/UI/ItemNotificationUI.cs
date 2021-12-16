using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;
using System;

public class ItemNotificationUI : MonoBehaviour
{
    private DisplayInventory menu;
    [SerializeField] RectTransform rectTransform;
    private GameObject itemNotificationObj;
    [SerializeField] private TMP_Text itemNameText;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        itemNotificationObj = this.gameObject.transform.GetChild(0).gameObject;
    }

    private void Start()
    {
        InventoryEvent.currentInventoryEvent.onNameItemNotify += ItemName;
    }

    //EVENT THAT RECEIVES A CALL FROM InventorySO and sends an send to the player
    private void ItemName(string _ItemName)
    {
        Debug.Log("ITEM NAME" + _ItemName);
        itemNotificationObj.SetActive(true);
        itemNameText.SetText("You Got " + _ItemName);
        InventoryEvent.currentInventoryEvent.InputItemNotify(true);
    }

    public void CloseItemNotifyUI()
    {
        itemNotificationObj.SetActive(false);
    }



    // Update is called once per frame
    public void NotificationActivate()
    {

        menu = (DisplayInventory)FindObjectOfType(typeof(DisplayInventory));

        var instanceItemNot = Instantiate(this.gameObject, Vector3.zero, Quaternion.identity, menu.transform);
        instanceItemNot.transform.position = instanceItemNot.transform.parent.position;
        // playerInputDisabled.Invoke();

        menu.itemNotificationUI = instanceItemNot;
        // Debug.Log("ITEM NAME IS" + _itemName);

        //SET THIS AS THE CURRENTLY SELECTED OBJECT IN UI
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(this.gameObject);


    }

    void OnDisable()
    {
        InventoryEvent.currentInventoryEvent.onNameItemNotify -= ItemName;
    }
}
