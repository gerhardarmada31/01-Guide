using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Timer")]
public class TimerDecision : NPCDecision_SO
{
    public override bool Decide(NPCStateController controller)
    {

        bool timerIsDone = TimeDone(controller);
        return timerIsDone;
    }

    private bool TimeDone(NPCStateController controller)
    {

        if (controller.checkCountDownElapsed(controller.enemyStats.idleTime))
        {
            // Debug.Log("Time is up");

            return true;
        }
        else
        {
            return false;
        }

    }
}
