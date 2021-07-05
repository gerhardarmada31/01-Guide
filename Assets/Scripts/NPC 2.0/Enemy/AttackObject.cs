using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackObject : MonoBehaviour
{
    protected float objTimer;
    // Start is called before the first frame update
    protected void DestroyObject()
    {
        Destroy(gameObject, objTimer);
    }
}
