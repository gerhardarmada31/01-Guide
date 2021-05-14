using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackProjectile : AttackObject
{
    [SerializeField] private bool isProjectile;
    [SerializeField] private float fireSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * fireSpeed * Time.deltaTime);
    }
}
