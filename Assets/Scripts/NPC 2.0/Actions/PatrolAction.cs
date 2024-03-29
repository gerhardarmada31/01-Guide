using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Patrol")]
public class PatrolAction : NPCActions_SO
{
    public bool randomMode;

    public override void Act(NPCStateController controller)
    {
        Patrol(controller);
    }

    private void Patrol(NPCStateController controller)
    {

        //randomMode should be inside controller

        // Debug.unityLogger.Log("Entered Patrol Action");
    
        controller.NavMeshAgent.destination = controller.WayPoints[controller.WayPointIndex].position;
        controller.NavMeshAgent.isStopped = false;

        if (controller.NavMeshAgent.remainingDistance <= 1.0f && !controller.NavMeshAgent.pathPending)
        {
            controller.NavMeshAgent.isStopped = true;
            // Debug.Log("nextPosition");
            // if (randomMode)
            // {
            //     pointIndex = UnityEngine.Random.Range(0, controller.WayPoints.Count);
            // }
            controller.WayPointIndex = (controller.WayPointIndex + 1) % controller.WayPoints.Count;
        }
    }
}