using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionsButton : MonoBehaviour
{

    public TMPro.TextMeshProUGUI txtSessionName;
    public string sessionName;
    public int sessionId;
    float doubleClickCnt;
    DashboardController controller;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void activate(){
        //controller.InstantiateAnswers();
        //controller.CleanRespColor();
        txtSessionName.color=Color.white;
        gameObject.GetComponent<UnityEngine.UI.Image>().color=Color.green;
    }
    public void loadRounds(){
        controller.intsantiateSessions(sessionId);
    }
    public void init(int id, string name, DashboardController dc){
        sessionId = id;
        sessionName = name;
        controller = dc;
        txtSessionName.text=name;
    }
    public void click(){
        if((Time.time-doubleClickCnt) <0.6f){ //if doubleclick
            loadRounds();
            doubleClickCnt=0;
        }else{
            doubleClickCnt=Time.time;
        }
    }

    
}
