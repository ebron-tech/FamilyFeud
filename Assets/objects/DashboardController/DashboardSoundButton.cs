using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashboardSoundButton : MonoBehaviour
{
    public string sKeyDown, soundType;
    KeyCode keyPressed;
    DashboardSendOSC sendOSC;
    DashboardCanvasSwitch canvasSwitch;
    AutoComplete autoComp;
    void Start()
    {
        keyPressed = (KeyCode) System.Enum.Parse(typeof(KeyCode), sKeyDown.ToUpper() ) ;
        sendOSC = GameObject.FindObjectOfType<DashboardSendOSC>(); 
        canvasSwitch = GameObject.FindObjectOfType<DashboardCanvasSwitch>();
        autoComp =  GameObject.FindObjectOfType<AutoComplete>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyPressed)){
            triggerSound();
        }
    }
    public void triggerSound(){
        if(canvasSwitch.isFastMoneyTime){
            if(!autoComp.isTextInputSelected){
                sendOSC.soundAction(soundType);
            }
        }
        else{
            sendOSC.soundAction(soundType);
        }
    }
}
