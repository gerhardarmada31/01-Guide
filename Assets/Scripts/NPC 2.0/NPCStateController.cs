using System.Collections;
using System.Collections.Generic;
// using Assets.NPCScript;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NPCStateController : MonoBehaviour
{
    public NPCAttributes enemyStats;
    public NPCStates_SO remainState;
    private NPCStatus npcStatus;


    //Set up some of that good2x headers
    [SerializeField] private Transform eyes;
    [SerializeField] private Transform attackSpawner;
    [SerializeField] private Transform chaseTarget;
    [SerializeField] private float stateTimeElapsed = 0;
    [SerializeField] private float attackRate;
    [SerializeField] private GameObject attackObj;
    [SerializeField] private NPCStates_SO currentState;
    [SerializeField] private List<Transform> wayPoints;
    [SerializeField] private int wayPointIndex;
    [SerializeField] private GameObjectPool gameObjectPool;


    private NavMeshAgent navMeshAgent;


    //PROPERTIES
    public GameObjectPool GameObjectPool { get { return gameObjectPool; } }
    public bool IsplayerIn { get; set; }
    public NPCStatus NPCStatus
    {
        get { return npcStatus; }
    }
    public bool InitAttack { get; set; }

    public Transform AttackSpawner
    {
        get { return attackSpawner; }
    }

    public GameObject AttackObj
    {
        get { return attackObj; }
    }

    public Transform Eyes
    {
        get { return eyes; }
    }
    public Transform ChaseTarget
    {
        get { return chaseTarget; }

        set { chaseTarget = value; }
    }
    public int WayPointIndex
    {
        get { return wayPointIndex; }

        set { wayPointIndex = value; }
    }
    public List<Transform> WayPoints
    {
        get { return wayPoints; }
    }
    public NavMeshAgent NavMeshAgent
    {
        get
        {
            return navMeshAgent;
        }
    }

    private void Awake()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        npcStatus = GetComponent<NPCStatus>();
    }

    //This is getting passing the argument rather than the values won't set in the scriptable object
    void Update()
    {
        currentState.UpdateState(this);
    }

    private void OnDrawGizmos()
    {
        if (currentState != null && eyes != null)
        {
            Gizmos.color = currentState.sceneGizmoColor;
            Gizmos.DrawWireSphere(attackSpawner.position, enemyStats.lookSphereCastRadius);
        }
    }

    public void TransistionToState(NPCStates_SO nextState)
    {
        if (nextState != remainState)
        {
            currentState = nextState;
            OnExitState();
        }
    }

    public bool checkCountDownElapsed(float duration)
    {
        stateTimeElapsed += Time.deltaTime;
        return (stateTimeElapsed >= duration);
    }

    private void OnExitState()
    {
        stateTimeElapsed = 0;
    }

    //Probably change this into coroutine if this becomes trouble
    public bool TimerAttack(float duration)
    {
        attackRate += Time.deltaTime;

        if (attackRate >= duration)
        {
            attackRate = 0;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void PoolFire()
    {
        var shot = gameObjectPool.Get();
        shot.transform.rotation = transform.rotation;
        shot.transform.position = transform.position;
        shot.gameObject.SetActive(true);
    }
}
