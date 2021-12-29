using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.Events;

public class CommandRange : MonoBehaviour
{
    public List<GameObject> targetObj = new List<GameObject>();
    public Text targetText;
    private int targetIndex;

    private SphereCollider myCollider;
    private MMFeedbacks commandRangeFeel;
    private bool isDetected;

    public FriendDialogue MyFriend { get; set; }

    private bool isCommandModeOn;
    // private IShroudedObj shroudedObj;
    private PlayerStatus playerStatus;
    private PlayerInventory playerInventory;
    private PlayerDialogue playerDialogue;
    private GameObject playerObj;

    private LineRenderer targetLine;
    private bool canTarget = true;
    private GameObject selectedObj;
    public GameObject SelectedObj
    {
        get { return selectedObj; }
        set { selectedObj = value; }
    }


    // Probably create scriptable object to pass through values


    private void Awake()
    {
        commandRangeFeel = GetComponentInChildren<MMFeedbacks>();
        targetLine = GetComponent<LineRenderer>();
        targetLine.enabled = false;
        playerDialogue = GetComponentInParent<PlayerDialogue>();
        playerStatus = GetComponentInParent<PlayerStatus>();
        playerInventory = GetComponentInParent<PlayerInventory>();
        playerObj = this.transform.parent.gameObject;
        myCollider = this.GetComponent<SphereCollider>();
    }

    void Update()
    {
        if (targetIndex < targetObj.Count && targetObj[targetIndex] != null)
        {
            selectedObj = targetObj[targetIndex];
            targetText.text = targetObj[targetIndex].gameObject.name.ToString();
        }
        TargetLeyLine();
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
                // Debug.DrawLine(this.transform.parent.position, other.transform.position, Color.red);
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
        if (playerStatus.CurrentSP >= 1 && selectedObj != null && canTarget == true)
        {
            //calling the functions from the selected object and gives a reference for the player Obj
            TargetEventSystem.currentTarget.ConfirmTargetSelect(selectedObj, playerObj, playerStatus.TotalDmg);
            MyFriend = selectedObj.GetComponent<FriendDialogue>();
            var itemObj = selectedObj.GetComponent<Item>();

            if (itemObj != null)
            {
                playerInventory.inventory.AddItem(itemObj.item, itemObj.ItemAmount);
                InventoryEvent.currentInventoryEvent.InventoryUpdateUI(true);
            }

            if (MyFriend != null)
            {
                //checks if player is in a dialogue
                playerDialogue.IsInDialogue = true;
                DialogueController.Instance.dialogueRunner.StartDialogue(MyFriend.YarnStartNode);
            }
            Vector3 targetPos = new Vector3(selectedObj.transform.position.x, this.transform.position.y, selectedObj.transform.position.z);
            playerObj.transform.LookAt(targetPos);
            playerStatus.SpiritStack();
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
            // Debug.Log("cmdOn");
            commandRangeFeel?.PlayFeedbacks();
            StartCoroutine(WaitandPause(0.1f));
            isCommandModeOn = true;
        }
        else
        {
            if (this.enabled == true)
            {
                // Debug.Log("cmdOff");
                StopCoroutine(WaitandPause(0.1f));
                ClearingTarget();
                targetText.text = "None";
                Time.timeScale = 1f;
                isCommandModeOn = false;
            }
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

    public void TargetLeyLine()
    {
        RaycastHit hit;
        if (selectedObj != null)
        {
            var allLayers = ~(1 << 8);
            if (Physics.Linecast(this.transform.position, selectedObj.transform.position, out hit, allLayers))
            {
                // selectedObj = (hit.collider.gameObject);
                targetLine.enabled = true;
                targetLine.SetPosition(0, this.transform.position);
                // var targetPosition = selectedObj.transform.position - transform.position;

                //Checks if Leyline hits the target
                if (hit.collider)
                {
                    targetLine.SetPosition(1, hit.point);
                    Debug.Log(hit.collider.name);
                    if (hit.collider.transform.position != selectedObj.transform.position)
                    {
                        canTarget = false;
                    }
                    else
                    {
                        canTarget = true;

                    }

                }
                Debug.Log("TargetLinedUp");
            }
        }
        else
        {
            targetLine.enabled = false;
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
