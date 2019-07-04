using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using OscJack;
public class BoardOSCinputs : MonoBehaviour
{
    // Start is called before the first frame update
    BoardManager boardManager;
    //OscServer server;
    void Awake(){
        boardManager = gameObject.GetComponent<BoardManager>();
        //server = new OscServer(9001);
        
        /*server.MessageDispatcher.AddCallback(
        "/answr", // OSC address
        (string address, OscDataHandle data) => {
            Debug.Log(string.Format("Recieved: answr ({0})",data.GetElementAsInt(0)));
            boardManager.showResponse(data.GetElementAsInt(0));
            
            }   
        );
*/

    }
    void OnApplicationQuit(){
     //   server.Dispose();
    }

    // Update is called once per frame
    void Update()
    {

    }
    
}
