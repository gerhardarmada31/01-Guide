using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CommandRange : MonoBehaviour
{
    public List<GameObject> targetObj = new List<GameObject>();
    public Text myText;
    public GameObject selectedObj;
    public int selectedTarget;
    private bool isCommandModeOn;

    // Probably create scriptable object to pass through values
    public PlayerCharacter myPlayer = new PlayerCharacter();


    private void Awake()
    {
        myPlayer = this.gameObject.GetComponentInParent<PlayerCharacter>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.E))
        // {
        //     if (selectedTarget < targetObj.Count - 1)
        //     {
        //         selectedTarget++;
        //     }
        // }

        // if (Input.GetKeyDown(KeyCode.Q))
        // {
        //     selectedTarget--;
        //     if (selectedTarget <= -1)
        //     {
        //         selectedTarget = 0;
        //     }
        // }
        if (selectedTarget < targetObj.Count && targetObj[selectedTarget] != null)
        {
            selectedObj = targetObj[selectedTarget];
            myText.text = targetObj[selectedTarget].gameObject.name.ToString();
        }
    }

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
        // if (myPlayer.commandMode && selectedObj != null)
        // {
        //     myPlayer.commandMode = false;
        TargetEventSystem.current.ConfirmTargetSelect(selectedObj);

        //     //total SPcost
        //     myPlayer.CurrentSP -= 1 + myPlayer.StackSP;
        // }

        Debug.Log("ConfirmTarget");
    }

    public void ClearingTarget()
    {
        targetObj.Clear();
        selectedObj = null;
    }


    public bool CommandMode()
    {

        if (gameObject.activeSelf)
        {
            isCommandModeOn = true;
            StartCoroutine(GetTargetsFirst());
        }
        else
        {
            Time.timeScale = 1f;
            isCommandModeOn = false;
            StopCoroutine(GetTargetsFirst());
        }
        return isCommandModeOn;
    }

    IEnumerator GetTargetsFirst()
    {
        yield return new WaitForSeconds(0.1f);
        Time.timeScale = 0f;
    }
}
