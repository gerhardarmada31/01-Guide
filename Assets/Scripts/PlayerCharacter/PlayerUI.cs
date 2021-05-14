using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    //UI related stuff
    [SerializeField]
    private Text hpValue;
    [SerializeField]
    private Text spValue;
    [SerializeField]
    private Text spRate;
    [SerializeField]
    private Text spStack;

    private PlayerStatus playerStatus;
    // Start is called before the first frame update
    void Start()
    {
        playerStatus = GetComponent<PlayerStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        playerUI();
    }

    public void playerUI()
    {
        hpValue.text = playerStatus.CurrentHP.ToString();
        spValue.text = playerStatus.CurrentSP.ToString();
        spRate.text = playerStatus.spRate.ToString("F0");
        spStack.text = playerStatus.StackSP.ToString();
    }
}
