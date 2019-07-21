using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashboardCanvasSwitch : MonoBehaviour
{
    public GameObject DashboardCanvas, fastMoneyCanvas;
    public bool isFastMoneyTime;
    DashboardSendOSC sendOSC;
    void Start()
    {
        sendOSC = GameObject.FindObjectOfType<DashboardSendOSC>(); 
        DashboardCanvas.SetActive(true);
        fastMoneyCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int currentSession;
    public void goToFastMoney(){
        currentSession=DashboardCanvas.GetComponent<DashboardController>().sessionID;
        fastMoneyCanvas.SetActive(true);
        DashboardCanvas.SetActive(false);
        fastMoneyCanvas.GetComponent<AutoComplete>().sessionID=currentSession;
        fastMoneyCanvas.GetComponent<AutoComplete>().Start();
        isFastMoneyTime=true;
        sendOSC.changeScene(1);
    }
    public void goToDashboard(){
        fastMoneyCanvas.SetActive(false);
        DashboardCanvas.SetActive(true);
        isFastMoneyTime=false;
        sendOSC.changeScene(0);
    }
}
