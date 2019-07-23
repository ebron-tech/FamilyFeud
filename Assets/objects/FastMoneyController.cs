using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastMoneyController : MonoBehaviour
{
    
    public respFastMoney[] resp;
    public TMPro.TextMeshPro pointsTxt;
    BoardManager manager;
    int points;
    void Start()
    {
        manager= GameObject.FindObjectOfType<BoardManager>();
        disableFastMenu();
        //gameObject.SetActive(false);
    }
    void setRespActive(bool a){
        for(int i =0;i<resp.Length;i++){
            resp[i].status =0;
            resp[i].gameObject.SetActive(a);
            resp[i].hideResp();
            resp[i].status=0;
            points=0;
            pointsTxt.text=points+"";
            
        }
    }
    public void hideResp(){
        for(int i =0;i<resp.Length;i++){
            resp[i].hideResp();
        }
    }

    // Update is called once per frame
    void Update()
    {


        if(Input.GetKeyDown(KeyCode.Space)){
            activateFastMoney();
            Debug.Log("puplate");
            List<object> l= new List<object>();
            l.Add("Hello,1");
            l.Add("Yolo,2");
            l.Add("Mexc,3");
            l.Add("Pillow,4");
            l.Add("scarft,5");
            l.Add("text,6");
            l.Add("bag,7");
            l.Add("floor,8");
            l.Add("tile,9");
            l.Add("window,10");
            populateResp(l);
        }
    }

    public void populateResp(List<object> r){
        activateFastMoney();
        if(resp.Length==10){
            for(int i =0; i<10;i++){
                string aux = System.Convert.ToString( r[i]);
                Debug.Log(aux);
                string[] s= aux.Split(',');
                //Debug.Log(s.Length);
                if(s.Length==2){
                    string q = s[0];
                    int p;
                    if(q==resp[i].respText.text){continue;}
                    if(int.TryParse(s[1],out p)){
                        resp[i].setValues(q,p);
                        continue;
                    }
                }
                resp[i].setValues("",0);
                
            }
        }else{
            Debug.Log("arrayList is not size 10");
        }
    }
    
    
    public void showResponse(int id){
        if(id<resp.Length &&resp.Length >0){
            if( resp[id].showResponse()){
               // resp.clip=sounds[0];
                //resp.Play();
                points+=resp[id].getPoints();
                pointsTxt.text=points+"";
                //return true;
            };
        }
        //return false;
    }
    public void activateFastMoney(){

        setRespActive(true);
        manager.clearResp();

    }
    public void disableFastMenu(){
        setRespActive(false);
       // gameObject.SetActive(false);
    }
}
