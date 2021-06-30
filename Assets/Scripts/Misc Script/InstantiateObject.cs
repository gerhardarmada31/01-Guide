using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script name to bullet pooled
public class InstantiateObject : MonoBehaviour, IGameObjectPooled
{
    float lifeTime;
    float maxLifeTime = 5f;
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
                throw new System.Exception("Bad pool use, this should only get set once.");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * 3f * Time.deltaTime);
        lifeTime += Time.deltaTime;
        if (lifeTime >= maxLifeTime)
        {
            pool.ReturnToPool(this.gameObject);
        }
    }
    void OnEnable()
    {
        lifeTime = 0;
    }
    void OnTriggerEnter(Collider other)
    {
        //when hit return to pool as well;
    }
}
