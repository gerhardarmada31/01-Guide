using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CommandRange : MonoBehaviour
{
    public List<GameObject> targetObj = new List<GameObject>();
    public Text myText;

    private int targetIndex;

    private bool isCommandModeOn;

    private PlayerStatus playerStatus;
    private GameObject playerObj;

    private GameObject selectedObj;
    public GameObject SelectedObj
    {
        get { return selectedObj; }
        set { selectedObj = value; }
    }


    // Probably create scriptable object to pass through values


    private void Awake()
    {
        playerStatus = GetComponentInParent<PlayerStatus>();
        playerObj = this.transform.parent.gameObject;
    }

    void Start()
    {

    }


    void Update()
    {
        if (targetIndex < targetObj.Count && targetObj[targetIndex] != null)
        {
            selectedObj = targetObj[targetIndex];
            myText.text = targetObj[targetIndex].gameObject.name.ToString();
        }
    }

    //Finding a target that and add it to the list targetObj
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Target"))
        {
            if (other.transform.parent != null)
            {
                targetObj.Add(other.transform.parent.gameObject);
            }
            else
            {
                targetObj.Add(other.transform.gameObject);
            }

            Debug.Log(selectedObj);
        }
        else
        {
            myText.text = "None";
        }
    }
    private void OnDisable()
    {

    }

    private void OnEnable()
    {
        ClearingTarget();
    }

    public void ConfirmTarget()
    {
        if (playerStatus.CurrentSP >= 1 && selectedObj != null)
        {
            TargetEventSystem.current.ConfirmTargetSelect(selectedObj, playerObj);

            // ITakeDamage damage = selectedObj.GetComponent<ITakeDamage>();
            // if (damage != null)
            // {
            //     //get stats from playerStatus
            //     damage.TakeDamage(playerStatus.TotalDmg);
            // }
            playerStatus.SpiritSystem();
            Debug.Log("ConfirmTarget");
        }


        //substract spirit
    }

    public void ClearingTarget()
    {
        targetObj.Clear();
        selectedObj = null;
        targetIndex = 0;
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
            StopCoroutine(WaitandPause(0.1f));
            ClearingTarget();
            myText.text = "None";
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
}
