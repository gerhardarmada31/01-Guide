using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMelee : AttackObject
{
    [SerializeField] private float lifeTime;

    void Awake()
    {
        objTimer = lifeTime;
    }
    // Start is called before the first frame update
    void Start()
    {
        DestroyObject();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
