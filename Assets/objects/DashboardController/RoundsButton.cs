using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundsButton : MonoBehaviour
{
    public TMPro.TextMeshProUGUI txtQuestion;
    public int sessionId,roundId;
    public string question;
    UnityEngine.UI.Image imgBG;
    DashboardController controller;
    float doubleClickCnt;
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }
    public void init(int SessionId, int RoundId, string Question, DashboardController dc ){
        controller=dc;
        sessionId=SessionId;
        roundId=RoundId;
        question= Question;
        txtQuestion.text= question;
        imgBG = gameObject.GetComponent<UnityEngine.UI.Image>();
    }
    public void activate(){
        //controller.InstantiateAnswers();
        //controller.CleanRespColor();
        txtQuestion.color=Color.white;
        imgBG.color=Color.green;
    }
    public void loadResp(){
        Debug.Log("RoundLoadResp");
        controller.instantiateRounds(roundId);
        //controller.instantiateResp(roundId);
    }
    public void cleanColor(){
        txtQuestion.color=Color.black;
        imgBG.color=Color.grey;
    }
    public void click(){
        if((Time.time-doubleClickCnt) <0.6f){ //if doubleclick
            loadResp();
            doubleClickCnt=0;
        }else{
            doubleClickCnt=Time.time;
        }
    }

}
