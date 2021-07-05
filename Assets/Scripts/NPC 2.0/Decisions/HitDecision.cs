using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Hit")]
public class HitDecision : NPCDecision_SO
{
    public override bool Decide(NPCStateController controller)
    {
        bool hasBeenHit = HasBeenHit(controller);
        return hasBeenHit;
    }

    public bool HasBeenHit(NPCStateController controller)
    {
        if (controller.NPCStatus.PlayerObj != null)
        {
            controller.ChaseTarget = controller.NPCStatus.PlayerObj.transform;
            Debug.Log("I noticed you player");
            return true;
        }
        else
        {
            return false;
        }
        // return false;

    }
}
