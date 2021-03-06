﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using round;
using UnityEngine.EventSystems;// Required when using Event data.

public class AutoComplete : MonoBehaviour
{   
    public GameObject AutoCompleteElement;
    public GameObject anchor;
    public UnityEngine.UI.Button sendButton;
    List<string>[] respo;
    List<GameObject> VisualWords;
    public QuestionAnwswerContainer[] questionObj;

    Round[] rounds;
    List<string>[] quesWords;
    DashboardSendOSC sendOSC;
    string[] finalResponses;
    public int sessionID;
    public void Start(){
        rounds =util.getRoundsFromFolder("rounds");       
        sendOSC = GameObject.FindObjectOfType<DashboardSendOSC>(); 
        FastMoney[] f = rounds[sessionID].FastMoney;
        finalResponses  = new string[10];
        for(int i =0;i<10;i++){
            finalResponses[i]="";
        }
        quesWords= new List<string>[f.Length];
        VisualWords = new List<GameObject>();
        for(int i =0; i<f.Length;i++){
            quesWords[i]= new List<string>();
        }
        if(f.Length==5){
            for(int i =0; i<5;i++){
                questionObj[i].question.text=f[i].Question;
            //    Debug.Log(i+","+(i+5));
                questionObj[i+5].question.text=f[i].Question;
                foreach(Resp r in f[i].Resp){
                    quesWords[i].Add(r.Name.ToUpper()+","+r.Points);
                }
            }
        }
        questionObj[0].textField.Select();
        //input = gameObject.GetComponent<TMPro.TMP_InputField>();
    }
    
    string TopValue;
    int selectedID;
    public void checkRefs(int id){
        selectedID=id;
        id=Mathf.RoundToInt(Mathf.Repeat(id,5));
        //Debug.Log(selectedID +""+id);
        foreach (Transform child in anchor.transform) {
            GameObject.Destroy(child.gameObject);
        }
//        Debug.Log(VisualWords.Count);
        VisualWords.Clear();
        List<string> found = quesWords[id].FindAll( w => w.Contains(questionObj[selectedID].textField.text.ToUpper()) );
        TopValue = (found.Count>0)?found[0]:questionObj[selectedID].textField.text.ToUpper();
        foreach(string s in found){
           instantiateTxt(s);
       }
       isTextInputSelected=true;
    }

    void instantiateTxt(string str){
        GameObject auxobj= Instantiate(AutoCompleteElement,Vector3.zero,Quaternion.identity);
        auxobj.GetComponent<TMPro.TextMeshProUGUI>().text=str;
        auxobj.transform.SetParent(anchor.transform);
        auxobj.transform.position=Vector3.zero;
        VisualWords.Add(auxobj);
    }

    bool isEnterSelected;
    public bool isTextInputSelected;
    public void deselectedText(){
        isTextInputSelected=false;
    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.Tab)){
            finalResponses[selectedID]=TopValue;           
            questionObj[selectedID].textField.text=TopValue;
            questionObj[selectedID].button.interactable=true;

            if((selectedID+1)<10){
                questionObj[selectedID+1].textField.Select();
                isEnterSelected=false;
            }else{
                sendButton.Select();
                isEnterSelected=true;
            }
        }
        if(Input.GetKeyDown(KeyCode.Return)&&!isEnterSelected){// when the button is selected avoid to send the message twice pressing return.
                sendRespsViaOSC();
        }
         if(Input.GetKeyDown(KeyCode.H)){
            hideResp1();
        }
        
    }

    bool isHide;
    public void hideResp1(){
        sendOSC.hideFastMoneyResp((isHide)?1:0); 
        isHide = !isHide;
    }
    public void sendRespsViaOSC(){
        List<string> l=new List<string>();
        Debug.Log(l);
        l.AddRange(finalResponses);
        foreach(string s in finalResponses){
            Debug.Log(s);
        }
        sendOSC.sendFastMoneyAnswrs(l);
    }
}
