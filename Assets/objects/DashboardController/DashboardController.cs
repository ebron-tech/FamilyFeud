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

    int sessionID,roundID;
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
        cleanSessionObjs();
        for(int i =0; i< sessions.Length;i++){
            SessionsButton auxObj = Instantiate(sessionBtnPfb,Vector3.zero,Quaternion.identity).GetComponent<SessionsButton>();
            auxObj.init(i,"session-"+i,this);
            auxObj.transform.SetParent(sessionPannel.gameObject.transform);
            auxObj.transform.localScale=Vector3.one;
            sessionObjs.Add(auxObj);
        }
    }
    void instantiateSessions(int sessionID){
        
    }
    void instantiateRounds(int sessionID){
        cleanRoundObjs();
        for(int i =0; i< sessions[sessionID].Rounds.Length;i++){
            RoundsButton auxObj = Instantiate(roundsBtnPfb,Vector3.zero,Quaternion.identity).GetComponent<RoundsButton>();
            auxObj.init(sessionID,i,txtQuestion.text=sessions[sessionID].Rounds[i].Question,this);
            auxObj.transform.SetParent(roundsPannel.gameObject.transform);
            auxObj.transform.localScale=Vector3.one;
            if(roundID==i){auxObj.activate();}
            roundObjs.Add(auxObj);
        }
    }
    void instantiateResp(RoundElement rE){
        cleanAnwsObjs();
        txtQuestion.text=rE.Question;
        for( int i=0; i<rE.Resp.Length;i++){
            Answerbutton auxObj = Instantiate(respBtnPfb,Vector3.zero,Quaternion.identity).GetComponent<Answerbutton>();
            auxObj.init(i,(i+1)+"-"+rE.Resp[i].Name,rE.Resp[i].Points);
           // auxObj.GetComponent<UnityEngine.UI.Image>().rectTransform.localScale=Vector3.one;
            auxObj.transform.SetParent(respPannel.transform);
            auxObj.transform.localScale=Vector3.one;
            anwsrObjs.Add(auxObj);
        }
    }
    void instantiateResp(int id){
        instantiateResp(sessions[sessionID].Rounds[id]);
    }

    void nextRound(){
        if(roundID<sessions[sessionID].Rounds.Length-1){
            roundID++;
        }else{
            if(sessionID<sessions.Length-1){
             //   sessionID++;
            }
        }
        
    }
    void cleanSessionObjs(){
        for(int i =0; i<sessionObjs.Count;i++){
            GameObject.Destroy(sessionObjs[i].gameObject);
        }
        sessionObjs.Clear();
        sessionObjs=null;
        sessionObjs = new List<SessionsButton>();
    }
     void cleanRoundObjs(){
        for(int i =0; i<roundObjs.Count;i++){
            GameObject.Destroy(roundObjs[i].gameObject);
        }
        roundObjs.Clear();
        roundObjs=null;
        roundObjs = new List<RoundsButton>();
    }

    void cleanAnwsObjs(){
        for(int i =0; i<anwsrObjs.Count;i++){
            GameObject.Destroy(anwsrObjs[i].gameObject);
        }
        anwsrObjs.Clear();
        anwsrObjs=null;
        anwsrObjs = new List<Answerbutton>();
    }
    
}
