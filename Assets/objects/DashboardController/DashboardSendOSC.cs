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
    }
    void Start(){
    
     
    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            OSCHandler.Instance.SendMessageToClient("controller","resp/",1);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)){
            OSCHandler.Instance.SendMessageToClient("controller","resp/","2");            
        }
        if(Input.GetKeyDown(KeyCode.Alpha3)){
            OSCHandler.Instance.SendMessageToClient("controller","resp/",3);
        }
        if(Input.GetKeyDown(KeyCode.Alpha4)){
            OSCHandler.Instance.SendMessageToClient("controller","resp/","4");
        }
        if(Input.GetKeyDown(KeyCode.Alpha5)){
            OSCHandler.Instance.SendMessageToClient("controller","resp/",5);
        }
        if(Input.GetKeyDown(KeyCode.Alpha6)){
            OSCHandler.Instance.SendMessageToClient("controller","resp/","6");
        }
    }

   public void selectAnswr(int id){
    //    client.Send("/answr",id);
       // Debug.Log("SendOSC: answr "+id);
    }

    void OnApplicationQuit(){
   //     client.Dispose();
    }
}
