using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answerbutton : MonoBehaviour
{
    public TMPro.TextMeshProUGUI txtAnswer, txtPoints;
    public int points;
    public string answer;
    public int id;
    UnityEngine.UI.Button btn;
    UnityEngine.UI.Image imgBG;
    DashboardSendOSC sendOSC;
    KeyCode keyPressed;
    void Awake()
    {
        btn = gameObject.GetComponent<UnityEngine.UI.Button>();
        imgBG = gameObject.GetComponent<UnityEngine.UI.Image>();
        sendOSC = GameObject.FindObjectOfType<DashboardSendOSC>();
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyPressed)){
            showResp();
        }
    }
    public void init(int Id, string answ, int pnts){
        this.id=Id+1;
        answer=answ;
        points = pnts;
        btn.onClick.AddListener(showResp); 
        keyPressed = (KeyCode) System.Enum.Parse(typeof(KeyCode), "Alpha"+id) ;
        txtAnswer.text= answer;
        txtPoints.text=points+"";
    }

    public void showResp(){
        //txtAnswer.color=Color.white;
        imgBG.color=Color.green;
        sendOSC.selectAnswr(id);
        Debug.Log("buttonpressed:"+ id);
    }
    void updateText(){
        txtAnswer.text=answer;
        txtPoints.text=points+"";
    }
}
