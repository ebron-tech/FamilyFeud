using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using round;
public class DashboardController : MonoBehaviour
{
    public Round[] sessions;
    public GameObject sessionPannel, roundsPannel, respPannel;
    public GameObject sessionBtnPfb, roundsBtnPfb, respBtnPfb;
    public TMPro.TextMeshProUGUI txtQuestion;

    List<SessionsButton> sessionObjs;
    List<Answerbutton> anwsrObjs;
    List<RoundsButton> roundObjs;

    void Awake(){
        sessionObjs = new List<SessionsButton>();
        anwsrObjs = new List<Answerbutton>();
        roundObjs = new List<RoundsButton>();
        sessions = util.getRoundsFromFolder("rounds");
    }

    void Start(){
        initSessions();
        instantiateSessions(0);
        instantiateRounds(0);
        instantiateResp(sessions[0].Rounds[0]);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void initSessions(){
        for(int i =0; i< sessions.Length;i++){
            SessionsButton auxObj = Instantiate(sessionBtnPfb,Vector3.zero,Quaternion.identity).GetComponent<SessionsButton>();
            auxObj.init(i,"session-"+i,this);
            auxObj.transform.SetParent(sessionPannel.gameObject.transform);

            sessionObjs.Add(auxObj);
        }
    }
    void instantiateSessions(int sessionID){
        
    }
    void instantiateRounds(int sessionID){
        
        for(int i =0; i< sessions[sessionID].Rounds.Length;i++){
            RoundsButton auxObj = Instantiate(roundsBtnPfb,Vector3.zero,Quaternion.identity).GetComponent<RoundsButton>();
            auxObj.init(sessionID,i,txtQuestion.text=sessions[sessionID].Rounds[i].Question,this);
            auxObj.transform.SetParent(roundsPannel.gameObject.transform);
            roundObjs.Add(auxObj);
        }
    }
    void instantiateResp(RoundElement rE){
        txtQuestion.text=rE.Question;
        for( int i=0; i<rE.Resp.Length;i++){
            Answerbutton auxObj = Instantiate(respBtnPfb,Vector3.zero,Quaternion.identity).GetComponent<Answerbutton>();
            auxObj.init(i,rE.Resp[i].Name,rE.Resp[i].Points);
            auxObj.transform.SetParent(respPannel.transform);
            anwsrObjs.Add(auxObj);
        }
    }
}
