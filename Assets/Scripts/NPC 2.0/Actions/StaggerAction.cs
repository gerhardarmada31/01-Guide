using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "PluggableAI/Actions/Stagger")]
public class StaggerAction : NPCActions_SO
{
    public override void Act(NPCStateController controller)
    {
        Stagger(controller);
    }

    private void Stagger(NPCStateController controller)
    {
        // Debug.Log("Idle");
        controller.NavMeshAgent.isStopped = true;
        if (controller.TimerAttack(0.5f))
        {
            controller.NPCStatus.IsStagger = false;
        }
    }
}
