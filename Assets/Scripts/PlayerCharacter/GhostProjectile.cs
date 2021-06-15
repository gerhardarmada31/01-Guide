using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostProjectile : AttackObject
{
    public PlayerCharacter_SO playerStats;
    [SerializeField] private bool isProjectile;
    private Rigidbody rbBullet;
    [SerializeField] bool isBulletHoming;
    [SerializeField] GameObject targetObj;
    [SerializeField] private float fireSpeed;
    [SerializeField] private float bulletRotateSpeed = 100f;
    [SerializeField] private float lifeTime;

    void Awake()
    {
        //get the target from the command Range
        rbBullet = this.GetComponent<Rigidbody>();
        objTimer = lifeTime;
    }
    // Start is called before the first frame update
    void Start()
    {
        DestroyObject();
    }


    void FixedUpdate()
    {
        if (isBulletHoming)
        {
            Vector3 targetDir = targetObj.transform.position - gameObject.transform.position;
            targetDir.Normalize();
            Vector3 rotateAmount = Vector3.Cross(targetDir, gameObject.transform.up);
            // transform.position += transform.forward * 0.0001f;
            rbBullet.angularVelocity = -bulletRotateSpeed * rotateAmount;
            rbBullet.velocity = transform.up * fireSpeed;
        }
        else
        {
            rbBullet.velocity = transform.forward * fireSpeed;
        }

    }

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Terrain") || other.CompareTag("Enemy"))
        {
            ITakeDamage damage = other.GetComponent<ITakeDamage>();

            if (damage != null)
            {
                damage.TakeDamage(playerStats.attackPoint);
            }
            Destroy(gameObject);
        }
    }
}
