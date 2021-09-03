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
        Debug.Log("STAGGER");

        controller.NavMeshAgent.isStopped = true;
        if (controller.NPCStatus.IsStun)
        {
            if (controller.TimerAttack(controller.NPCStatus.StaggerTime))
            {
                controller.NPCStatus.IsHit = false;
                controller.NPCStatus.IsStun = false;
            }
        }
        else
        {
            if (controller.TimerAttack(0.1f))
            {
                controller.NPCStatus.IsHit = false;
            }
        }

    }
}
