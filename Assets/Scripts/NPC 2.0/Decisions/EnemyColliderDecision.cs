using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Collider")]
public class EnemyColliderDecision : NPCDecision_SO
{
    public override bool Decide(NPCStateController controller)
    {
        // bool targetDetected = controller.IsplayerIn;
        bool targetDetected = NotInSight(controller);
        return targetDetected;
    }

    private bool NotInSight(NPCStateController controller)
    {
        if (controller.ChaseTarget != null)
        {
            var attackLayer = ~(1 << 8);
            RaycastHit hit;
            if (Physics.Linecast(controller.AttackSpawner.position, controller.ChaseTarget.position, out hit, attackLayer)
             && hit.collider.CompareTag("Player"))
            {
                // Debug.Log("PlayahIn");
                return true;
            }
            else
            {
                // controller.ChaseTarget = null;
                return false;
            }
            // return true;
        }
        return false;

    }
}
