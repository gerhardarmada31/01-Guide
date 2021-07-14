using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CommandRange : MonoBehaviour
{
    public List<GameObject> targetObj = new List<GameObject>();
    public Text targetText;

    private int targetIndex;
    private SphereCollider myCollider;

    public FriendDialogue MyFriend { get; set; }

    private bool isCommandModeOn;
    // private IShroudedObj shroudedObj;
    private PlayerStatus playerStatus;
    private PlayerDialogue playerDialogue;
    private GameObject playerObj;
    private bool isDetected;

    private GameObject selectedObj;
    public GameObject SelectedObj
    {
        get { return selectedObj; }
        set { selectedObj = value; }
    }


    // Probably create scriptable object to pass through values


    private void Awake()
    {
        playerDialogue = GetComponentInParent<PlayerDialogue>();
        playerStatus = GetComponentInParent<PlayerStatus>();
        playerObj = this.transform.parent.gameObject;
        myCollider = this.GetComponent<SphereCollider>();
    }

    void Start()
    {

    }


    void Update()
    {
        if (targetIndex < targetObj.Count && targetObj[targetIndex] != null)
        {
            selectedObj = targetObj[targetIndex];
            targetText.text = targetObj[targetIndex].gameObject.name.ToString();
        }
    }

    //Finding a target that and add it to the list targetObj
    private void OnTriggerEnter(Collider other)
    {
        //make an interface called itargetable or something
        //Make list next of targetable Objects
        var enemy = other.GetComponent<NPCStatus>();

        if (other.CompareTag("Target"))
        {
            //give a condition of the player has received the scanner 2.0
            TargetEventSystem.currentTarget.ShroudDetected(other.gameObject, false);
            if (other.transform.parent != null)
            {
                targetObj.Add(other.transform.parent.gameObject);
            }
            else
            {
                targetObj.Add(other.transform.gameObject);
            }
        }
        else
        {
            targetText.text = "None";
        }
    }


    private void OnEnable()
    {
        ClearingTarget();
    }

    public void ConfirmTarget()
    {
        if (playerStatus.CurrentSP >= 1 && selectedObj != null)
        {
            //calling the functions from the selected object and gives a reference for the player Obj
            TargetEventSystem.currentTarget.ConfirmTargetSelect(selectedObj, playerObj, playerStatus.TotalDmg);
            MyFriend = selectedObj.GetComponent<FriendDialogue>();

            if (MyFriend != null)
            {
                //checks if player is in a dialogue
                playerDialogue.IsInDialogue = true;
                DialogueController.Instance.dialogueRunner.StartDialogue(MyFriend.YarnStartNode);
            }

            playerObj.transform.LookAt(selectedObj.transform);
            playerStatus.SpiritSystem();
            // Debug.Log("ConfirmTarget");
        }
    }

    public void ClearingTarget()
    {
        targetObj.Clear();
        selectedObj = null;
        targetIndex = 0;
    }

    void OnDisable()
    {
        foreach (var allTargets in targetObj)
        {
            TargetEventSystem.currentTarget.ShroudDetected(allTargets, true);
        }
    }


    //When the game object is on, get the targets then time will stop
    public bool CommandMode()
    {
        if (gameObject.activeSelf)
        {
            StartCoroutine(WaitandPause(0.1f));
            isCommandModeOn = true;
        }
        else
        {
            Debug.Log("cmdOn");
            StopCoroutine(WaitandPause(0.1f));
            ClearingTarget();
            targetText.text = "None";
            Time.timeScale = 1f;
            isCommandModeOn = false;
        }
        return isCommandModeOn;
    }

    public void CommandSelect(float selectOperator)
    {
        if (selectOperator <= -1)
        {
            targetIndex = (targetIndex - 1) % targetObj.Count;

            if (targetIndex <= -1)
            {
                targetIndex = targetObj.Count - 1;
            }
        }
        else if (selectOperator >= 1)
        {
            targetIndex = (targetIndex + 1) % targetObj.Count;
        }
    }

    IEnumerator WaitandPause(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Time.timeScale = 0f;
    }

    public void MoreRange()
    {
        transform.localScale = new Vector3(20, 20, 20);
    }

    public bool detectedObj()
    {
        return isDetected;
    }
}
