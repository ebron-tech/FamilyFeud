using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashboardCanvasSwitch : MonoBehaviour
{
    public GameObject DashboardCanvas, fastMoneyCanvas;
    public bool isFastMoneyTime;

    void Start()
    {
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
    }
    public void goToDashboard(){
        fastMoneyCanvas.SetActive(false);
        DashboardCanvas.SetActive(true);
        isFastMoneyTime=false;
    }
}
