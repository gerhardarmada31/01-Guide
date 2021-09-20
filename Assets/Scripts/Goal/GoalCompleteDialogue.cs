using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class GoalCompleteDialogue : MonoBehaviour
{
    [SerializeField] public DialogueRunner dialogueRunner;
    private HashSet<string> completedGoals = new HashSet<string>();

    private void Awake()
    {
        dialogueRunner = GetComponent<DialogueRunner>();
    }
    
    void Start()
    {
        GoalEvent.currentGoalEvent.onGoalComplete += GoalCompleteCheck;
        dialogueRunner.AddFunction("GoalComplete", 1, delegate (Yarn.Value[] parameters)
        {
            // var speakerGoal = parameters[0];
            // if (parameters[0].AsBool == goalChecker)
            // {
            //     Debug.Log(parameters[0].AsString);
            // }
            var goalName = parameters[0];
            return completedGoals.Contains(goalName.AsString);
        }
        );
        // dialogueRunner.ad
    }

    private void GoalCompleteCheck(string goalCompletedName,bool goalComplete)
    {
        Debug.Log("goalTitleAdded");
        Debug.Log(goalComplete);
        completedGoals.Add(goalCompletedName);        // goalChecker = goalComplete;
    }
}
