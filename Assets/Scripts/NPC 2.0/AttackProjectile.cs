using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackProjectile : AttackObject
{
    public EnemyStats enemyStats;
    [SerializeField] private bool isProjectile;
    private Rigidbody rbBullet;
    [SerializeField] bool isBulletHoming;
    [SerializeField] GameObject targetObj;
    [SerializeField] private float fireSpeed;
    [SerializeField] private float bulletRotateSpeed = 100f;
    [SerializeField] private float lifeTime;

    void Awake()
    {
        rbBullet = this.GetComponent<Rigidbody>();
        objTimer = lifeTime;
    }
    // Start is called before the first frame update
    void Start()
    {
        DestroyObject();

    }

    // Update is called once per frame

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

        if (other.CompareTag("Terrain") || other.CompareTag("Player"))
        {
            ITakeDamage damage = other.GetComponent<ITakeDamage>();

            if (damage != null)
            {
                damage.TakeDamage(enemyStats.attackDamage);
            }
            Destroy(gameObject);
        }
    }
}