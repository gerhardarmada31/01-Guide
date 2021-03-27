using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Scan")]
public class ScanDecision : NPCDecision_SO
{
    public override bool Decide(NPCStateController controller)
    {
        bool noEnemyInSight = Scan(controller);
        return noEnemyInSight;
    }

    private bool Scan(NPCStateController controller)
    {
        controller.NavMeshAgent.isStopped = true;
        controller.transform.Rotate(0, controller.enemyStats.searchingTurnSpeed * Time.deltaTime, 0);
        return controller.checkCountDownElapsed(controller.enemyStats.searchDuration);
    }
}
