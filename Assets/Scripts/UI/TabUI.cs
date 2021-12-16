using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabUI : MonoBehaviour
{
    [SerializeField] private Sprite selectedImg;
    private Sprite currentImg;
    [SerializeField] private Sprite deselectedImg;

    void Awake()
    {
        // currentImg = this.GetComponent<Image>().sprite;
        // deselectedImg = currentImg;
    }

    public void TabSelected(bool _isSelected)
    {
        if (_isSelected)
        {
            this.gameObject.GetComponent<Image>().sprite = selectedImg;
        }
        else
        {
            this.gameObject.GetComponent<Image>().sprite = deselectedImg;
        }
    }
}
