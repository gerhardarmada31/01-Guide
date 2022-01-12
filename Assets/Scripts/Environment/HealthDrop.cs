using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDrop : MonoBehaviour
{
    [SerializeField] private int healthDropAmount;

    void OnTriggerEnter(Collider other)
    {
        ICollector _hpDropCollect =other.GetComponent<ICollector>();

        if (_hpDropCollect != null)
        {
            _hpDropCollect.GetCollectDrop(healthDropAmount, DropType.HEALTH);
            Object.Destroy(this.gameObject);
        }
    }
}
