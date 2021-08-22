using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class EnemyStatus : NPCStatus
{
    private int hp;
    private int spChecks;
    private MMFeedbacks enemyFeedBack;

    // public bool IsStagger { get; set; }

    // private bool isEnemyDead;
    // public bool IsEnemyDead
    // {
    //     get { return isEnemyDead; }
    //     set { isEnemyDead = value; }
    // }

    private bool isEnemyDead;

    private void Awake()
    {
        hp = TotalHp;
        enemyFeedBack = GetComponentInChildren<MMFeedbacks>();
    }
    // Update is called once per frame
    void Update()
    {
        Death();
    }

    // void OnEnable()
    // {
    // }


    protected override void OnDisable()
    {
        base.OnDisable();
        hp = TotalHp;
        // StopCoroutine(BeforeDeath());
    }

    protected override void ObjectTargeted(GameObject obj, GameObject playerObj, int sentSp)
    {
        // Debug.Log("Break");
        //only work if time is moving.
        if (obj == this.gameObject && obj != null)
        {
            enemyFeedBack?.PlayFeedbacks();
            PlayerObj = playerObj;
            hp -= sentSp;
            Debug.Log($"{this.gameObject} took {sentSp} Damage");

            if (sentSp <= SpCheckLvl1)
            {
                Debug.Log("Weak sauce");
                IsStagger = true;
                //Change behaviour because of npcStateController
                //
            }
            else if (sentSp >= SpCheckLvl2)
            {
                Debug.Log("strong Sauce");
            }

            if (hp <= 0)
            {
                isEnemyDead = true;
                GoalEvent.currentGoalEvent.KillUpdate(this.transform.parent.gameObject, isEnemyDead);
                enemyFeedBack?.PlayFeedbacks();
                StartCoroutine(BeforeDeath(0.2f));

            }
        }
    }

    public void Death()
    {

    }

    private void OnDestroy()
    {

    }

    protected override void Start()
    {
        base.Start();
    }

    IEnumerator BeforeDeath(float _time)
    {
        yield return new WaitForSeconds(_time);
        Debug.Log("sup");
        this.transform.parent.gameObject.SetActive(false);
    }


}
