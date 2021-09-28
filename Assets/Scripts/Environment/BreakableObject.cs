using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    [SerializeField] private int breakableObjHP;
    [SerializeField] private GameObject dropPrefab;

    void Start()
    {
        TargetEventSystem.currentTarget.onConfirmTargetSelect += ObjectConfirmed;
    }

    private void ObjectConfirmed(GameObject obj, GameObject playerObj, int sentSp)
    {
        if (obj == this.gameObject)
        {
            breakableObjHP -= sentSp;

            if (breakableObjHP <= 0)
            {
                DropObject();
                gameObject.SetActive(false);
            }
        }

    }

    public void DropObject()
    {
        bool isObjDropped = false;

        if (isObjDropped == false && this.enabled)
        {
            Instantiate(dropPrefab, gameObject.transform.position, gameObject.transform.rotation);
            isObjDropped = true;
        }

    }


    private void OnDisable()
    {
        TargetEventSystem.currentTarget.onConfirmTargetSelect -= ObjectConfirmed;
    }
}
