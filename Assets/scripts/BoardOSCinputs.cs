using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardOSCinputs : MonoBehaviour
{
    // Start is called before the first frame update
    BoardManager boardManager;
    public FastMoneyController fmoneyController;
    public int port =9001;
    //OscServer server;
    void Awake(){
        OSCHandler.Instance.Init("server",port);
        boardManager = gameObject.GetComponent<BoardManager>();

    }
    void OnApplicationQuit(){
     //   server.Dispose();
    }

    string key="test/";
    void Update()
    {
        for(int i=0; i<OSCHandler.Instance.packets.Count;i++){
            //controllByOSCmessage(OSCHandler.Instance.packets[i].Address,System.Convert.ToString(OSCHandler.Instance.packets[i].Data[0]));
            controllByOSCmessage(OSCHandler.Instance.packets[i].Address,OSCHandler.Instance.packets[i].Data);
            OSCHandler.Instance.packets.RemoveAt(i);
        }
            
    }
    void controllByOSCmessage(string addres, List<object> values){
        switch(addres){
            case "resp/":
                Debug.Log(values[0]);
                boardManager.showResponse(int.Parse(System.Convert.ToString(values[0])));
            break;
            case "winner/":
                Debug.Log("Server-TakeThePoints:"+values[0]);
                boardManager.takeThePoints(System.Convert.ToString(values[0]));
            break;
            case "strike/":
                Debug.Log("Server- strike:"+values[0]);
                boardManager.strike(System.Convert.ToInt32(values[0]));
            break;
            case "fmAnswrs/":
                fmoneyController.populateResp(values);
                foreach(object o in values){
                    Debug.Log(o);
                }
            break;
            case "loadRound/":
                string str= System.Convert.ToString(values[0]);
                int session = int.Parse( str.Split(',')[0]);
                int round = int.Parse(str.Split(',')[1]);
                boardManager.loadQuestionsByIds(session,round);
            break;
            case "repeated/":
                Debug.Log("Server-repeatedAudio()");
                boardManager.repeatedAnswer();
            break;
            case "changeScene/":
            Debug.Log("Server-changeScene"+System.Convert.ToInt32(values[0]));
                switch(System.Convert.ToInt32(values[0])){
                    case 0:
                        fmoneyController.disableFastMoneu();
                    break;
                    case 1: 
                        fmoneyController.activateFastMoney();
                    break;
                }
            break;
            
            default:
                Debug.Log("Server-DefaultCase: "+addres);
            break;
        }
    }
    
}
