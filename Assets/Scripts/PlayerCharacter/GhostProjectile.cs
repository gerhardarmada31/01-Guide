using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostProjectile : MonoBehaviour
{
    [SerializeField] private Rigidbody rbProjectile;
    [SerializeField] private GameObject targetObj;
    [SerializeField] private float projectileSpeed = 5f;
    [SerializeField] private float projectileRotateSpeed = 100f;

    void Awake()
    {
        rbProjectile = this.GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        Vector3 targetDir = targetObj.transform.position - gameObject.transform.position;
        targetDir.Normalize();
        Vector3 rotateAmount = Vector3.Cross(targetDir, gameObject.transform.up);
        // transform.position += transform.forward * 0.0001f;
        rbProjectile.angularVelocity = -projectileRotateSpeed * rotateAmount;
        rbProjectile.velocity = transform.up * projectileSpeed;
    }
}
