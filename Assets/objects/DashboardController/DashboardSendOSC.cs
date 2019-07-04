using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OscJack;
public class DashboardSendOSC : MonoBehaviour
{
    OscClient client;
    public string Address="127.0.0.1";
    public int port =9001;
    void Start(){
       client = new OscClient(Address, port);
    }

   public void selectAnswr(int id){
        client.Send("/answr",id);
       // Debug.Log("SendOSC: answr "+id);
    }

    void OnApplicationQuit(){
        client.Dispose();
    }
}
