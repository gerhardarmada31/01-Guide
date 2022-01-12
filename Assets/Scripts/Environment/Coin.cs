using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int coinAmount;

    void OnTriggerEnter(Collider other)
    {
        ICollector _coinCollector = other.GetComponent<ICollector>();

        if (_coinCollector != null)
        {
            _coinCollector.GetCollectDrop(coinAmount, DropType.COIN);
            Object.Destroy(this.gameObject);
        }
    }
}
