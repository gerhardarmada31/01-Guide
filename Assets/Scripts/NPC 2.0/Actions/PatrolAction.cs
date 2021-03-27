using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Patrol")]
public class PatrolAction : NPCActions_SO
{
    public bool randomMode;
    private int pointIndex;

    public override void Act(NPCStateController controller)
    {
        Patrol(controller);
    }

    private void Patrol(NPCStateController controller)
    {

        //randomMode should be inside controller
        
        controller.WayPointIndex = pointIndex;
        // Debug.unityLogger.Log("Entered Patrol Action");
        controller.NavMeshAgent.destination = controller.WayPoints[pointIndex].position;
        controller.NavMeshAgent.isStopped = false;

        if (controller.NavMeshAgent.remainingDistance <= controller.NavMeshAgent.stoppingDistance && !controller.NavMeshAgent.pathPending)
        {
            if (randomMode)
            {
                pointIndex = UnityEngine.Random.Range(0, controller.WayPoints.Count);
            }
            pointIndex = (pointIndex + 1) % controller.WayPoints.Count;
        }
    }
}