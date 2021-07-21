using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Hit")]
public class TalkDecision : NPCDecision_SO
{
    public override bool Decide(NPCStateController controller)
    {
        bool hasBeenHit = HasBeenHit(controller);
        return hasBeenHit;
    }

    public bool HasBeenHit(NPCStateController controller)
    {
        // return false;

        if (controller.FriendStatus != null)
        {
            if (controller.FriendStatus.FriendIsTalking)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
            return false;
    }
}
