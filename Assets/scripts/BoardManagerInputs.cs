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
    bool isHide;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            if(fmController.isFastMoneyRunning){
                fmController.showResponse(0);
            }else{
                boardManager.showResponse(0);
            }
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)){
           if(fmController.isFastMoneyRunning){
                fmController.showResponse(1);
            }else{
                boardManager.showResponse(1);
            }
        }
        if(Input.GetKeyDown(KeyCode.Alpha3)){
            if(fmController.isFastMoneyRunning){
                fmController.showResponse(2);
            }else{
                boardManager.showResponse(2);
            }
        }
        if(Input.GetKeyDown(KeyCode.Alpha4)){
            if(fmController.isFastMoneyRunning){
                fmController.showResponse(3);
            }else{
                boardManager.showResponse(3);
            }
        }
        if(Input.GetKeyDown(KeyCode.Alpha5)){
            if(fmController.isFastMoneyRunning){
                fmController.showResponse(4);
            }else{
                boardManager.showResponse(4);
            }
        }
        if(Input.GetKeyDown(KeyCode.Alpha6)){
            if(fmController.isFastMoneyRunning){
                fmController.showResponse(5);
            }else{
                boardManager.showResponse(5);
            }
        }
        if(Input.GetKeyDown(KeyCode.Alpha7)){
            if(fmController.isFastMoneyRunning){
                fmController.showResponse(6);
            }else{
                boardManager.showResponse(6);
            }
        }
        if(Input.GetKeyDown(KeyCode.Alpha8)){
            if(fmController.isFastMoneyRunning){
                fmController.showResponse(7);
            }else{
                boardManager.showResponse(7);
            }
        }
        if(Input.GetKeyDown(KeyCode.Alpha9)){
            if(fmController.isFastMoneyRunning){
                fmController.showResponse(8);
            }else{
                boardManager.showResponse(8);
            }
        }
        if(Input.GetKeyDown(KeyCode.Alpha0)){
            if(fmController.isFastMoneyRunning){
                fmController.showResponse(9);
            }else{
                boardManager.showResponse(9);
            }
        }
        if(Input.GetKeyDown(KeyCode.H)){
            fmController.hideResp((isHide)?0:1);
            isHide=!isHide;
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
