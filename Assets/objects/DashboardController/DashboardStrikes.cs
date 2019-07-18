using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashboardStrikes : MonoBehaviour
{
public UnityEngine.UI.Button singleStrike; 
public UnityEngine.UI.Button strike; 
public TMPro.TextMeshProUGUI strikesCountTxt;
DashboardSendOSC sendOSC;
int strikesCount;
    void Start()
    {
        sendOSC = GameObject.FindObjectOfType<DashboardSendOSC>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift)){
            if(Input.GetKeyDown(KeyCode.X)){
                ActivateSingleStrike();
            }
        }else{
            if(Input.GetKeyDown(KeyCode.X)){
                ActivateStrike();
            }
        }
    }
    public void ActivateSingleStrike(){
        //sendOSC.sendStrikes(1);
        Debug.Log("singleStrike");
    }
    public void ActivateStrike(){
        Debug.Log("Strike");
        strikesCount++;
       // sendOSC.sendStrikes(strikesCount);
        strikesCountTxt.text="x"+strikesCount;
    }

    public void ActivateResetStrikes(){
        strikesCount=0;
        strikesCountTxt.text="x"+strikesCount;
    }

}
