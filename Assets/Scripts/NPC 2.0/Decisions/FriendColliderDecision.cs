using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/FriendCollider")]
public class FriendColliderDecision : NPCDecision_SO
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
            // var attackLayer = ~(1 << 8);
            // RaycastHit hit;
            if (controller.ChaseTarget.CompareTag("Player"))
            {
                // Debug.Log("PlayahIn");
                return true;
            }
            else
            {
                controller.ChaseTarget = null;
                return false;
            }
            // return true;
        }
        return false;

    }
}
