using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.Events;

public class CommandRange : MonoBehaviour
{
    public List<GameObject> targetObj = new List<GameObject>();
    private int targetIndex;

    private SphereCollider myCollider;
    private MMFeedbacks commandRangeFeel;
    private bool isDetected;

    public FriendDialogue MyFriend { get; set; }
    private EnemyStatus enemyChecker;

    private bool isCommandModeOn;
    // private IShroudedObj shroudedObj;
    private PlayerStatus playerStatus;
    private PlayerInventory playerInventory;
    private PlayerDialogue playerDialogue;
    private GameObject playerObj;
    private SpiritUI spiritUI;

    //TARGET 
    private string targetName;
    private string targetAct;
    private string targetAct01;
    private string targetAct02;
    private int targetReq01;
    private int targetReq02;
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
        spiritUI = playerStatus.spUI;
        playerInventory = GetComponentInParent<PlayerInventory>();
        playerObj = this.transform.parent.gameObject;
        myCollider = this.GetComponent<SphereCollider>();
    }

    void Update()
    {
        if (targetIndex < targetObj.Count && targetObj[targetIndex] != null)
        {
            selectedObj = targetObj[targetIndex];
            // targetText.text = targetObj[targetIndex].gameObject.name.ToString();

            // TargetInfo _targetInfo = selectedObj.GetComponent<TargetInfo>();
            // if (_targetInfo != null)
            // {
            //     Debug.Log("GEY TARGET INFO");
            //     _targetInfo.GetInfo(out targetName, out targetAct);
            //     //updates the UI of targetINFOR
            //     TargetEventSystem.currentTarget.TargetInfoUpdate(targetName, targetAct, isCommandModeOn);

            // }
            ITargetInfo targetinfo = selectedObj.GetComponent<ITargetInfo>();
            if (targetinfo != null)
            {
                targetinfo.GetTargetInfo(out targetName, out targetAct01, out targetAct02, out targetReq01, out targetReq02);
                Debug.Log($"GETTING ALL ON targetName {targetName}, the action01 is {targetAct01}");

                //get current spStack amount and check if they have been met.
                if ((playerStatus.StackSP + 1) >= targetReq02)
                {
                    TargetEventSystem.currentTarget.TargetInfoUpdate(targetName, targetAct02, isCommandModeOn);
                }
                else
                {
                    TargetEventSystem.currentTarget.TargetInfoUpdate(targetName, targetAct01, isCommandModeOn);
                }
            }
        }
        TargetLeyLine();
    }

    //Finding a target that and add it to the list targetObj
    private void OnTriggerEnter(Collider other)
    {
        //make an interface called itargetable or something
        //Make list next of targetable Objects
        var enemy = other.GetComponent<NPCStatus>();


        //CHECKS if target has tag of "Target"
        if (other.CompareTag("Target"))
        {
            //Checks if target has targetInfo and reveals the targets shroud effect, also reveals the object

            //give a condition of the player has received the scanner 2.0
            TargetEventSystem.currentTarget.ShroudDetected(other.gameObject, false);
            targetObj.Add(other.transform.gameObject);
            // targetIndex = (targetIndex + 1) % targetObj.Count;
            // if (other.transform.parent != null && other.transform.parent.CompareTag("Enemy"))
            // {
            //     // Debug.DrawLine(this.transform.parent.position, other.transform.position, Color.red);
            //     targetObj.Add(other.transform.parent.gameObject);
            // }
            // else
            // {
            // }

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


            enemyChecker = selectedObj.GetComponent<EnemyStatus>();
            if (enemyChecker != null)
            {
                //SENDS A CONFIRMATION SPIRIT CHARGE ON HOSTILE OBJECTS
                TargetEventSystem.currentTarget.ConfirmTargetSelect(selectedObj, playerObj, playerStatus.TotalDmg);
                Debug.Log("TARGET IS ENEMY" + playerStatus.TotalDmg);


            }
            else
            {
                //SENDS A CONFIRMATION SPIRIT CHARGE ON NON-HOSTILE OBJECTS
                TargetEventSystem.currentTarget.ConfirmTargetSelect(selectedObj, playerObj, playerStatus.StackSP + 1);
                Debug.Log("TARGET IS FRIEND" + (playerStatus.StackSP + 1));

                //calling the functions from the selected object and gives a reference for the player Obj
                MyFriend = selectedObj.GetComponent<FriendDialogue>();
                var itemObj = selectedObj.GetComponent<Item>();

                // ShroudedObject npcShroud = selectedObj.GetComponent<ShroudedObject>();
                // if (npcShroud != null)
                // {
                //     Debug.Break();
                //     TargetEventSystem.currentTarget.ShroudDetected(selectedObj.gameObject, false);
                // }

                if (itemObj != null)
                {
                    playerInventory.inventory.AddItem(itemObj.item, itemObj.ItemAmount);
                    InventoryEvent.currentInventoryEvent.InventoryUpdateUI(true);
                }

                if (MyFriend != null)
                {
                    //checks if player is in a dialogue
                    // playerDialogue.IsInDialogue = true;
                    // DialogueController.Instance.dialogueRunner.StartDialogue(MyFriend.YarnStartNode);
                }
                Vector3 targetPos = new Vector3(selectedObj.transform.position.x, this.transform.position.y, selectedObj.transform.position.z);
                // Debug.Log("ConfirmTarget");
                playerObj.transform.LookAt(targetPos);
            }
            playerStatus.SpiritStack();

        }
    }

    public void ClearingTarget()
    {
        targetObj.Clear();
        selectedObj = null;
        targetIndex = 0;
        TargetEventSystem.currentTarget.TargetInfoUpdate(targetName, targetAct, false);

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
            spiritUI.CommandModeOn(true);
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
                spiritUI.CommandModeOn(false);
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

            //Layers are able to hit the layers
            int layer_mask = LayerMask.GetMask("Enemy", "Interactable", "Terrain", "Bullet");
            if (Physics.Linecast(this.transform.position, selectedObj.transform.position, out hit, layer_mask))
            {
                // selectedObj = (hit.collider.gameObject);
                targetLine.enabled = true;
                targetLine.SetPosition(0, Vector3.zero);
                // var targetPosition = selectedObj.transform.position - transform.position;

                //Checks if Leyline hits the target
                if (hit.collider)
                {
                    // var _object = hit.point-this.transform.position;
                    // targetLine.world
                    targetLine.SetPosition(1, this.transform.InverseTransformPoint(hit.point));
                    Debug.Log(hit.collider.name);
                    if (hit.collider.transform.position != selectedObj.transform.position)
                    {
                        canTarget = false;
                        TargetEventSystem.currentTarget.TargetInfoUpdate(targetName, "BLOCKED", isCommandModeOn);
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
