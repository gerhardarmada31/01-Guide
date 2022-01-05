using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabUI : MonoBehaviour
{
    // private Sprite currentImg
    [SerializeField] private Sprite initImg;
    [SerializeField] private Sprite selectedImg;
    [SerializeField] private Sprite deselectedImg;

    private void OnEnable()
    {

        this.gameObject.GetComponent<Image>().sprite = initImg;
    }
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
