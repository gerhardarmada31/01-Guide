using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{

    public PlayerStatus pStats;
    [SerializeField] private GameObject hpCell;
    [SerializeField] private GameObject hpCellE;
    // public 

    private void Awake()
    {
        // pStats = FindObjectOfType<PlayerStatus>();
        if (pStats == null)
        {
            Debug.LogError("Player status is empty on UI, set something to it");
        }
    }

    public void DrawHeart(int _hp, int _maxHp)
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < _maxHp; i++)
        {
            if (i + 1 <= _hp)
            {
                GameObject hp = Instantiate(hpCell, transform.position, Quaternion.identity);
                hp.transform.SetParent(transform, false);
            }
            else
            {
                GameObject hp = Instantiate(hpCellE, transform.position, Quaternion.identity);
                hp.transform.SetParent(transform, false);
                // hp.transform.parent = transform;
            }
        }
    }
}
