using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManagerInputs : MonoBehaviour
{
    BoardManager boardManager;
    FastMoneyController fmController;
    void Start(){
        boardManager = GameObject.FindObjectOfType<BoardManager>();
        fmController = GameObject.FindObjectOfType<FastMoneyController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            boardManager.showResponse(0);
            fmController.showResponse(0);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)){
            boardManager.showResponse(1);
            fmController.showResponse(1);
        }
        if(Input.GetKeyDown(KeyCode.Alpha3)){
            boardManager.showResponse(2);
            fmController.showResponse(2);
        }
        if(Input.GetKeyDown(KeyCode.Alpha4)){
            boardManager.showResponse(3);
            fmController.showResponse(3);
        }
        if(Input.GetKeyDown(KeyCode.Alpha5)){
            boardManager.showResponse(4);
            fmController.showResponse(4);
        }
        if(Input.GetKeyDown(KeyCode.Alpha6)){
            boardManager.showResponse(5);
            fmController.showResponse(5);
        }
        if(Input.GetKeyDown(KeyCode.Alpha7)){
            boardManager.showResponse(6);
            fmController.showResponse(6);
        }
        if(Input.GetKeyDown(KeyCode.Alpha8)){
            boardManager.showResponse(7);
            fmController.showResponse(7);
        }
        if(Input.GetKeyDown(KeyCode.Alpha9)){
            boardManager.showResponse(8);
            fmController.showResponse(8);
        }
        if(Input.GetKeyDown(KeyCode.Alpha0)){
            boardManager.showResponse(9);
            fmController.showResponse(9);
        }
        if(Input.GetKeyDown(KeyCode.H)){
            fmController.hideResp();
        }
      
        //Plays the repeated sound
        if(Input.GetKeyDown(KeyCode.R)){
            boardManager.repeatedAnswer();
        }
        //Trigger Strikes
        if(Input.GetKeyDown(KeyCode.X)){
            boardManager.strike();
        }
        //Load the next round
        if(Input.GetKey(KeyCode.LeftShift)){
            if(Input.GetKeyDown(KeyCode.RightArrow)){
                boardManager.nextRound();
            }
        }else{
            //Assing points to team
            if(Input.GetKeyDown(KeyCode.LeftArrow)){
                boardManager.takeThePoints("L");
            }
            if(Input.GetKeyDown(KeyCode.RightArrow)){
                boardManager.takeThePoints("R");
            }
        }

    }
}
