using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Look")]
public class LookDecision : NPCDecision_SO
{
    //Edit this later for using a gameobject that has collision sphere

    public override bool Decide(NPCStateController controller)
    {
        bool targetVisible = Look(controller);
        return targetVisible;
    }

    private bool Look(NPCStateController controller)
    {
        //CHANGE THIS BASED ON ENEMYSTATS COLLISIONSPHERE
        RaycastHit hit;

        Debug.DrawRay(controller.Eyes.position, controller.Eyes.forward.normalized * controller.enemyStats.lookRange, Color.green);


        if (Physics.SphereCast(controller.Eyes.position, controller.enemyStats.lookSphereCastRadius, controller.Eyes.forward, out hit, controller.enemyStats.lookRange)
            && hit.collider.CompareTag("Player"))
        {

            controller.ChaseTarget = hit.transform;
            return true;
        }
        else
        {
            return false;
        }
    }
}
