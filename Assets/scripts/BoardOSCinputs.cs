using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardOSCinputs : MonoBehaviour
{
    // Start is called before the first frame update
    BoardManager boardManager;
    public int port =9001;
    //OscServer server;
    void Awake(){
        boardManager = gameObject.GetComponent<BoardManager>();
        OSCHandler.Instance.Init("server",port);

    }
    void OnApplicationQuit(){
     //   server.Dispose();
    }

    string key="test/";
    void Update()
    {
        for(int i=0; i<OSCHandler.Instance.packets.Count;i++){
            controllByOSCmessage(OSCHandler.Instance.packets[i].Address,System.Convert.ToString(OSCHandler.Instance.packets[i].Data[0]));
            OSCHandler.Instance.packets.RemoveAt(i);
        }
            
    }
    void controllByOSCmessage(string addres, string value){
        switch(addres){
            case "test/":
            Debug.Log(value);
                boardManager.showResponse(int.Parse(value));
            break;
            case "round/":
            break;
            case "action/":
            break;
            default:
                Debug.Log("DefaultCase: "+addres);
            break;
        }
    }
    
}
