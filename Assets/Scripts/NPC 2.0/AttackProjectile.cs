using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackProjectile : AttackObject, IGameObjectPooled
{
    public NPCAttributes enemyStats;
    [SerializeField] private bool isProjectile;
    private Rigidbody rbBullet;
    [SerializeField] bool isBulletHoming;
    [SerializeField] GameObject targetObj;
    [SerializeField] private float fireSpeed;
    [SerializeField] private float bulletRotateSpeed = 100f;
    [SerializeField] private float lifeTime;
    [SerializeField] private float totalLifeTime = 5f;

    private GameObjectPool pool;

    public GameObjectPool Pool
    {
        get { return pool; }
        set
        {
            if (pool == null)
            {
                pool = value;
            }
            else
            {
                throw new System.Exception("Bad pool, this should only get set once");
            }
        }
    }
    void Awake()
    {
        rbBullet = this.GetComponent<Rigidbody>();
        objTimer = lifeTime;
    }
    // Start is called before the first frame update
    void Start()
    {
        // DestroyObject();

    }
    void OnEnable()
    {
        lifeTime = 0;
    }

    // Update is called once per frame

    void FixedUpdate()
    {
        //Change this to coroutine next time
        lifeTime += Time.deltaTime;
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

        if (lifeTime >= totalLifeTime)
        {
            pool.ReturnToPool(this.gameObject);
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
            pool.ReturnToPool(this.gameObject);
        }
    }
}

//make an independent script for this
internal interface IGameObjectPooled
{
    GameObjectPool Pool { get; set; }
}