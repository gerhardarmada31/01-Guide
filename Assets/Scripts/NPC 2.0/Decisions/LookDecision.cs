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


        Debug.DrawRay(controller.AttackSpawner.position, controller.AttackSpawner.forward.normalized * controller.enemyStats.lookRange, Color.green);

        Vector3 _originalEyePos = controller.Eyes.position;

        if (Physics.SphereCast(controller.AttackSpawner.position, controller.enemyStats.lookSphereCastRadius, controller.Eyes.forward, out hit, controller.enemyStats.lookRange)
            && hit.collider.CompareTag("Player"))
        {
            controller.ChaseTarget = hit.transform;
            // controller.Eyes.position = hit.transform.position;
            return true;
        }
        // if(Physics.Raycast(controller.AttackSpawner.position, controller.AttackSpawner.forward.normalized, out hit, controller.enemyStats.lookRange)
        //  && hit.collider.CompareTag("Player"))
        // {
        //     controller.ChaseTarget = hit.transform;
        //     controller.Eyes.position = hit.transform.position;
        // }
        else
        {
            // controller.IsplayerIn =false;
            return false;
        }






    }
}
