using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Attack")]
public class AttackAction : NPCActions_SO
{
    public override void Act(NPCStateController controller)
    {
        Attack(controller);
    }

    private void Attack(NPCStateController controller)
    {
        if (controller.ChaseTarget != null)
        {
            controller.NavMeshAgent.destination = controller.ChaseTarget.position;

            if (Vector3.Distance(controller.NavMeshAgent.transform.position, controller.ChaseTarget.position) <= 2.5f)
            {
                controller.NavMeshAgent.isStopped = true;
                if (controller.TimerAttack(controller.enemyStats.attackRate))
                {
                    Debug.Log("AI Attacking");
                    Instantiate(controller.AttackObj, controller.Eyes.transform);
                }

            }
            else
            {
                controller.NavMeshAgent.isStopped = false;
            }

        }
    }
}
