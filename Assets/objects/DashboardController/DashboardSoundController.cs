using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///DELETE THIS IS SCRIPT IS USELESS! 😅
public class DashboardSoundController : MonoBehaviour
{
    DashboardSendOSC sendOSC;
    public DashboardSoundButton duplicated, game,ring,fast,win,begin,exit;
    void Start()
    {
        sendOSC = GameObject.FindObjectOfType<DashboardSendOSC>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void sendSound(string soundType){
        sendOSC.soundAction(soundType);
    }
}
