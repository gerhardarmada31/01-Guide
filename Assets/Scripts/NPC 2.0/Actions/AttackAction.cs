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
            // controller.NavMeshAgent.destination = controller.ChaseTarget.position;

            // if (Vector3.Distance(controller.NavMeshAgent.transform.position, controller.ChaseTarget.position) <= 3.0f)
            // {
            //     


            // }
            // else
            // {
            //     controller.NavMeshAgent.isStopped = false;
            // }


            if (!controller.InitAttack && controller.NavMeshAgent.isStopped == true)
            {
                controller.NavMeshAgent.isStopped = true;
                Instantiate(controller.AttackObj, controller.AttackSpawner.transform);
                controller.InitAttack = true;
            }

            if (controller.TimerAttack(controller.enemyStats.attackRate) && controller.NavMeshAgent.isStopped == true)
            {
                Debug.Log("AI Attacking");
                Instantiate(controller.AttackObj, controller.AttackSpawner.transform);
                controller.InitAttack = false;
            }

        }
    }
}
