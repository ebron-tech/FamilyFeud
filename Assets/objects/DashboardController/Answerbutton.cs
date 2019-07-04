using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answerbutton : MonoBehaviour
{
    public TMPro.TextMeshProUGUI txtAnswer, txtPoints;
    public int points;
    public string answer;
    public int id;
    BoardOSCinputs sendOSCmessage;
    UnityEngine.UI.Button btn;
    UnityEngine.UI.Image imgBG;
    DashboardSendOSC sendOSC;
    void Awake()
    {
        btn = gameObject.GetComponent<UnityEngine.UI.Button>();
        imgBG = gameObject.GetComponent<UnityEngine.UI.Image>();
        sendOSCmessage = gameObject.GetComponent<BoardOSCinputs>();
        sendOSC = GameObject.FindObjectOfType<DashboardSendOSC>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    public void init(string answ, int pnts){
        answer=answ;
        points = pnts;
        btn.onClick.AddListener(showResp);
    }

    public void showResp(){
        txtAnswer.color=Color.white;
        imgBG.color=Color.green;
        sendOSC.selectAnswr(id);
        Debug.Log("buttonpressed:"+ id);
    }
    void updateText(){
        txtAnswer.text=answer;
        txtPoints.text=points+"";
    }
}
