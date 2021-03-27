using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/Decisions/Collider")]
public class ColliderDecision : NPCDecision_SO
{
    public override bool Decide(NPCStateController controller)
    {
        bool targetDetected = controller.IsplayerIn;
        return targetDetected;
    }
}
