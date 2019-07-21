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
    int strikes;
    int turn;
    int currentPoints, leftPoints,rightPoints;
    int sessionID,roundID;
    bool pointsGivedToTeam;
    VisualBoard visualBoard;
    //Sounds Array 
    //0->Correct
    //1->Incorrect
    //2->Repeated
    public AudioClip[] sounds;
    AudioSource audioSrc;
    strikeController strikeCtl;

    void Awake(){
        sessions = util.getRoundsFromFolder("rounds");
        //Debug.Log(sessions[0].Rounds[0].Question);
        audioSrc= gameObject.GetComponent<AudioSource>();
        visualBoard= gameObject.GetComponent<VisualBoard>();
        strikeCtl= gameObject.GetComponent<strikeController>();
        Application.runInBackground=true;
    }


    void Start(){
        //load the init Sessions and Rounds by index (0,0)
        loadQuestionsByIds(sessionID,roundID);
    }

    // Update is called once per frame
    void Update(){
        
    }   
    //Summary:
    //     Clear the response boxes and create them from the file.
    // Parameters:
    //   value:
    //     sesionId = the id of the session ( the file )
    //     roundId = the id for the round
    public  void loadQuestionsByIds(int sessionId, int roundId){
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
    // Summary:
    //     Load all the responses and order them following the size of positionAnchor
    // Parameters:
    //   value:
    //      Recieves a Resp array from sessions[n]
    private void instantiateResp(Resp[] r){
        //Ordenate each respObject (this method gets a little messy🙈)
        int respLenght=r.Length;
        float respDistance= positionAnchor.localScale.y/respLenght;
        respDistance= (positionAnchor.localScale.y-respDistance)/respLenght;
        float topPos= positionAnchor.position.y+(positionAnchor.localScale.y*0.5f)-respDistance;
        for(int i =0; i<respLenght;i++){
            float localDist = respDistance*i;
            RespObject auxObj = Instantiate(respObjectPrefab,(new Vector3(0,topPos-localDist,0)),Quaternion.identity).GetComponent<RespObject>();
            auxObj.setValues(i+1,r[i].Name,r[i].Points);
            respObjects.Add(auxObj);
            //Each element is instantiated with a unique position, 
            //the RespObject is stored in to a temporal variable 
            //in order to initialize each box with the response and the points
            //the tmp variable is stored inside one list.
        }
    }
     // Summary:
    //     Cleans the response boxes, removes from scene, and clean the respObjects List
    public  void clearResp(){
        if(respObjects!=null){
            foreach(RespObject r in respObjects){
                GameObject.Destroy(r.gameObject);
            }
            respObjects=null;
        }
        respObjects = new List<RespObject>();
    }
     // Summary:
    //     Shows the response for each response 
    // Parameters:
    //   value:
    //      Recieves the index of each response and show it, 
    //      plays the sound, add the points to CurrentPoints variable and updates the visual text.
    public void showResponse(int id){
        if(id<respObjects.Count){
            if( respObjects[id].showResponse()){
                audioSrc.clip=sounds[0];
                audioSrc.Play();
                currentPoints+=respObjects[id].getPoints();
                visualBoard.updateCurrentPoints(currentPoints);
                //return true;
            };
        }
        //return false;
    }
    
    // Summary:
    //     Sums the currentPoints to one Team
    // Parameters:
    //   value:
    //     select the team who wins the points. 
    //      1=Left Team.
    //      2=Right Team.
    public void takeThePoints(string team){
        if(!pointsGivedToTeam){
            strikes=0;
            switch(team){
                case "L":
                    leftPoints+=currentPoints;
                    visualBoard.updateLeftPoints(leftPoints);
                    pointsGivedToTeam=true;
                    break;
                case "R":
                    rightPoints+=currentPoints;
                    visualBoard.updateRightPoints(rightPoints);
                    pointsGivedToTeam=true;
                    break;
                default:
                    break;
            }
        }
    }
    public bool nextRound(){
        if(pointsGivedToTeam){
            if(roundID<sessions[sessionID].Rounds.Length){
                roundID++;
                loadQuestionsByIds(sessionID,roundID);
                visualBoard.updateCurrentPoints(currentPoints=0);
                pointsGivedToTeam=false;
                return true;
            }else{
                return false;
            }
        }return false;
    }
    public void repeatedAnswer(){
        audioSrc.clip=sounds[2];
        audioSrc.Play();
    }
    public void strike(){
        if(strikes <3){
            strikes++;
            strikeCtl.triggerStrike(strikes);
            audioSrc.clip=sounds[1];
            audioSrc.Play();
            Debug.Log(strikes);
        }
    }
    public void strike(int count){
        strikeCtl.triggerStrike(count);
        audioSrc.clip=sounds[1];
        audioSrc.Play();
        Debug.Log(strikes);
    }

}
