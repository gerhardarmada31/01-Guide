using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/HitDecision")]
public class HitDecision : NPCDecision_SO
{
    public override bool Decide(NPCStateController controller)
    {
        // throw new System.NotImplementedException();
        bool gotHit = EnemyHit(controller);
        return gotHit;
    }

    private bool EnemyHit(NPCStateController controller)
    {
        // throw new NotImplementedException();
        if (controller.NPCStatus.IsStagger == true)
        {
            return true;
        }
        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
