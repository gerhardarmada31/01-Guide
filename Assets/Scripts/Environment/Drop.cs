using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public DropType dropType;
    [SerializeField] int dropAmount;

    //Checks the enum of the obj and checks if the player has touched the obj
    void OnTriggerEnter(Collider other)
    {
        ICollector _dropCollect = other.GetComponent<ICollector>();

        if (_dropCollect != null)
        {
            switch (dropType)
            {
                case DropType.HEALTH:
                    Debug.Log("HP");
                    _dropCollect.GetCollectDrop(dropAmount, dropType);
                    break;

                case DropType.SPIRIT:
                    Debug.Log("SP");
                    _dropCollect.GetCollectDrop(dropAmount, dropType);
                    break;

                case DropType.COIN:
                    Debug.Log("Coin");
                    _dropCollect.GetCollectDrop(dropAmount, dropType);
                    break;

                default:
                    Debug.LogError("No Drop Type has been set");
                    break;
            }

            Object.Destroy(this.gameObject);
        }
    }
}
