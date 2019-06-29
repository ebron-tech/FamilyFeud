using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManagerInputs : MonoBehaviour
{
    BoardManager boardManager;
    void Start(){
        boardManager = GameObject.FindObjectOfType<BoardManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            boardManager.showResponse(0);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)){
            boardManager.showResponse(1);
        }
        if(Input.GetKeyDown(KeyCode.Alpha3)){
            boardManager.showResponse(2);
        }
        if(Input.GetKeyDown(KeyCode.Alpha4)){
            boardManager.showResponse(3);
        }
        if(Input.GetKeyDown(KeyCode.Alpha5)){
            boardManager.showResponse(4);
        }
        if(Input.GetKeyDown(KeyCode.Alpha6)){
            boardManager.showResponse(5);
        }
        if(Input.GetKeyDown(KeyCode.Alpha7)){
            boardManager.showResponse(6);
        }
        if(Input.GetKeyDown(KeyCode.Alpha8)){
            boardManager.showResponse(7);
        }
        if(Input.GetKeyDown(KeyCode.Alpha9)){
            boardManager.showResponse(8);
        }
        
        if(Input.GetKeyDown(KeyCode.RightArrow)){
            boardManager.nextRound();
        }

        if(Input.GetKey(KeyCode.LeftShift)){
            if(Input.GetKeyDown(KeyCode.LeftArrow)){
                boardManager.takeThePoints(1);
            }
            if(Input.GetKeyDown(KeyCode.RightArrow)){
                boardManager.takeThePoints(2);
            }
        }

    }
}
