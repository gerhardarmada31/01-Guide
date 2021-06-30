using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is the gun
public class BlasterShotPool : MonoBehaviour
{
    [SerializeField]
    private float refireRate = 2f;
    [SerializeField]
    GameObjectPool gameObjectPool;
    private float fireTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fireTimer += Time.deltaTime;
        if (fireTimer >= refireRate)
        {
            fireTimer = 0;
            Fire();
        }
    }

    private void Fire()
    {
        var shot = gameObjectPool.Get();
        shot.transform.rotation = transform.rotation;
        shot.transform.position = transform.position;
        shot.gameObject.SetActive(true);

    }
}
