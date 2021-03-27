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

            if (Vector3.Distance(controller.NavMeshAgent.transform.position, controller.ChaseTarget.position) <= 3.5f)
            {
                if (controller.TimerAttack(controller.enemyStats.attackRate))
                {
                    Debug.Log("Attack");
                    Instantiate(controller.AttackObj, controller.Eyes.transform);
                }

            }

        }
    }
}
