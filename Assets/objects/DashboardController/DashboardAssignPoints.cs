using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashboardAssignPoints : MonoBehaviour
{
    DashboardSendOSC sendOSC;

    public UnityEngine.UI.Button L_button;
    public UnityEngine.UI.Button R_button;
    public UnityEngine.UI.Button assign_button;
    string activeButton;
    void Start()
    {
        sendOSC = GameObject.FindObjectOfType<DashboardSendOSC>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            selectLeftButton();
        }
        if(Input.GetKeyDown(KeyCode.RightArrow)){
            selectRightButton();
        }
        if(Input.GetKeyDown(KeyCode.Return)){
            assginPointsOCS();
        }
    }
    public void selectLeftButton(){
        L_button.GetComponent<UnityEngine.UI.Image>().color=Color.green;
        R_button.GetComponent<UnityEngine.UI.Image>().color=Color.gray;
        activeButton="L";
    }
    public void selectRightButton(){
        L_button.GetComponent<UnityEngine.UI.Image>().color=Color.gray;
        R_button.GetComponent<UnityEngine.UI.Image>().color=Color.green;
        activeButton="R";
    }
    void deselectButtons(){
        L_button.GetComponent<UnityEngine.UI.Image>().color=Color.white;
        R_button.GetComponent<UnityEngine.UI.Image>().color=Color.white;
        activeButton="";
    }
    public void assginPointsOCS(){
        if(activeButton!=""){
           // sendOSC.assginWinner(activeButton);
            deselectButtons();
        }else{
            L_button.GetComponent<UnityEngine.UI.Image>().color=Color.gray;
            R_button.GetComponent<UnityEngine.UI.Image>().color=Color.gray;
        }
    }

}
