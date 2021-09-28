using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritDrop : MonoBehaviour
{
    [SerializeField] private int spiritDropAmount;

    void OnTriggerEnter(Collider other)
    {
        ICollector _spDropCollect = other.GetComponent<ICollector>();

        if (_spDropCollect != null)
        {
            _spDropCollect.GetCollectDrop(spiritDropAmount, dropType.SPIRIT);
            Object.Destroy(this.gameObject);
        }
    }
}
