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

        //Testing:   
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

        if(resp.Length==10){
            for(int i =0; i<resp.Length;i++){
                string aux = System.Convert.ToString( r[i]);
                Debug.Log(aux);
                string s= aux.Split(',')[0];
                int p=  int.Parse(aux.Split(',')[1]);
                resp[i].setValues(s,p);
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
