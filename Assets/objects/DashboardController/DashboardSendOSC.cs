using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityOSC;
public class DashboardSendOSC : MonoBehaviour
{
//    OscClient client;
    public string address="127.0.0.1";
    public int port =9001;
    void Awake(){
        OSCHandler.Instance.Init("controller",address,port);
        GameObject.DontDestroyOnLoad(this);
    }
    void Start(){
    
     
    }
    void Update(){
       /* if(Input.GetKeyDown(KeyCode.Alpha1)){
            OSCHandler.Instance.SendMessageToClient("controller","resp/",0);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)){
            OSCHandler.Instance.SendMessageToClient("controller","resp/","1");            
        }
        if(Input.GetKeyDown(KeyCode.Alpha3)){
            OSCHandler.Instance.SendMessageToClient("controller","resp/",2);
        }
        if(Input.GetKeyDown(KeyCode.Alpha4)){
            OSCHandler.Instance.SendMessageToClient("controller","resp/","3");
        }
        if(Input.GetKeyDown(KeyCode.Alpha5)){
            OSCHandler.Instance.SendMessageToClient("controller","resp/",4);
        }
        if(Input.GetKeyDown(KeyCode.Alpha6)){
            OSCHandler.Instance.SendMessageToClient("controller","resp/","5");
        }*/
        
    }

   public void selectAnswr(int id){
       OSCHandler.Instance.SendMessageToClient("controller","resp/",(id-1));
    //   client.Send("/answr",id);
        Debug.Log("SendOSC: answr "+id);
    }
    public void sendFastMoneyAnswrs(List<string> answs){
        OSCHandler.Instance.SendMessageToClient("controller","fmAnswrs/",answs);
    //   client.Send("/answr",id);
        Debug.Log("SendOSC: fmAnswrs "+answs);
    }
    public void hideFastMoneyResp(){
        OSCHandler.Instance.SendMessageToClient("controller","hidefm/",1);
    }
    public void sendStrikes(int strikeCount){
        OSCHandler.Instance.SendMessageToClient("controller","strike/",strikeCount);
    }
    public void assginWinner(string winnerSide){
        OSCHandler.Instance.SendMessageToClient("controller","winner/",winnerSide);
    }
    public void loadRound(int session,int round){
       OSCHandler.Instance.SendMessageToClient("controller","loadRound/",session+","+round);
       Debug.Log("loadScene:"+session+","+round);
    }
    public void changeScene(int i){
        OSCHandler.Instance.SendMessageToClient("controller","changeScene/",i);
        Debug.Log("goFastMoney:"+i);
        
    }
    public void repeated(int i =1){
        OSCHandler.Instance.SendMessageToClient("controller","repeated/",i);
    } 
    

    void OnApplicationQuit(){
     //   client.Dispose();
    }
}
