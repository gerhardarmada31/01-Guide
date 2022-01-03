using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemNavigation : MonoBehaviour
{
    private RectTransform itemContainer;
    // private float maxScroll = -150f;
    // private float minScroll = -50f;
    [SerializeField] float scrollVal = 50f;
    public InventorySO inventory;
    private int totalItems;
    private int currentPage = 1;
    private int maxPage = 1;

    private GameObject[] itemPage1;

    private void Awake()
    {
        itemContainer = this.gameObject.GetComponent<RectTransform>();
    }

    //Gets the event and the total items from the players inventory
    //Also increases the maxpage of items if the players has more than enough items
    private void OnEnable()
    {
        InventoryEvent.currentInventoryEvent.onItemNavigate += ItemScroll;
        totalItems = inventory.Container.Count;


        if (totalItems > 13)
        {
            for (int i = 0; i < 12; i++)
            {

            }
            maxPage = 2;
            if (totalItems > 25)
            {
                maxPage = 3;
            }
        }
    }

    private void ItemScroll(float _yScroll)
    {
        // _yScroll = _yScroll * -1f;
        _yScroll *= -1f;


        Debug.Log("THE ITEM SCROLL" + itemContainer.transform.localPosition.y);
        // itemContainer.transform.localPosition += new Vector3(0, scrollVal * _yScroll, 0);

        if (_yScroll > 0)
        {
            MoveDown();
        }
        else if (_yScroll < 0)
        {
            MoveUp();
        }

        // if (itemContainer.transform.localPosition.y <= maxScroll)
        // {
        //     itemContainer.transform.localPosition = new Vector3(0, maxScroll, 0);
        // }


    }

    private void MoveDown()
    {
        Debug.Log("MOVE DOWN");
        if (currentPage >= maxPage)
        {

        }
        else
        {
            currentPage++;
            itemContainer.transform.localPosition += new Vector3(0, scrollVal, 0);
        }
    }

    private void MoveUp()
    {
        Debug.Log("MOVE UP");

        itemContainer.transform.localPosition += new Vector3(0, -scrollVal, 0);
        currentPage--;
        if (currentPage <= 1)
        {
            currentPage = 1;
        }
    }

    void OnDisable()
    {
        InventoryEvent.currentInventoryEvent.onItemNavigate -= ItemScroll;
    }
}
