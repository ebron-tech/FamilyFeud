using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using round;
public class BoardManager : MonoBehaviour
{
    
    public GameObject respObjectPrefab;
    public Transform positionAnchor;
    Round[] sessions;
    List<RespObject> respObjects;
    void Awake(){
        sessions = util.getRoundsFromFolder("rounds");
        Debug.Log(sessions[0].Rounds[0].Question);
    }


    void Start(){
        loadQuestionsByIds(0,0);
    }

    // Update is called once per frame
    void Update(){
        
    }   
    public void loadQuestionsByIds(int sessionId, int roundId){
        if(sessionId<sessions.Length){
            if(roundId<sessions[sessionId].Rounds.Length){
                clearResp();
                instantiateResp(sessions[sessionId].Rounds[roundId].Resp);
            }else{
                Debug.Log("That sesion exist but the round dont");
            }
        }else{
            Debug.Log("That session does not exist");
        }
    }
    private void instantiateResp(Resp[] r){
        //Ordenate each respObject (order gets a little messy)
        int respLenght=r.Length;
        float respDistance= positionAnchor.localScale.y/respLenght;
        respDistance= (positionAnchor.localScale.y-respDistance)/respLenght;
        float topPos= positionAnchor.position.y+(positionAnchor.localScale.y*0.5f)-respDistance;
        for(int i =0; i<respLenght;i++){
            float localDist = respDistance*i;
            Debug.Log(localDist);
            RespObject auxObj = Instantiate(respObjectPrefab,(new Vector3(0,topPos-localDist,0)),Quaternion.identity).GetComponent<RespObject>();
            auxObj.setValues(i+1,r[i].Name,r[i].Points);
           // auxObj.transform.parent= positionAnchor;
            respObjects.Add(auxObj);
        }
    }
    private void clearResp(){
        if(respObjects!=null){
            foreach(RespObject r in respObjects){
                GameObject.Destroy(r.gameObject);
            }
            respObjects=null;
        }
        respObjects = new List<RespObject>();
    }
    public bool showResponse(int id){
        if(id<respObjects.Count){
            respObjects[id].showResponse();
            return true;
        }
        return false;
    }
}
