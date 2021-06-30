using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/LongRangeAttack")]
public class LongRangeAttackAction : NPCActions_SO
{
    public override void Act(NPCStateController controller)
    {
        LongRangeAttack(controller);
    }

    private void LongRangeAttack(NPCStateController controller)
    {
        if (controller.ChaseTarget != null)
        {
            if (!controller.InitAttack)
            {
                Instantiate(controller.AttackObj, controller.AttackSpawner.transform.position, controller.AttackSpawner.transform.rotation);
                controller.InitAttack = true;
            }

            if (controller.TimerAttack(controller.enemyStats.attackRate))
            {
                controller.PoolFire();
                // Debug.Log("AI Attacking");
                // Instantiate(controller.AttackObj, controller.AttackSpawner.transform.position, controller.AttackSpawner.transform.rotation);
            }
        }
    }
}
