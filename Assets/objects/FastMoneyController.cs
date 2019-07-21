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
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void populateResp(List<object> r){

        if(resp.Length==10){
            for(int i =0; i<resp.Length;i++){
                string aux = System.Convert.ToString( r[i]);
                Debug.Log(aux);
                string s= aux.Split()[0];
                int p=  int.Parse(aux.Split()[1]);
                resp[i].setValues(s,p);
            }
        }else{
            Debug.Log("arrayList is not size 10");
        }
    }

    
    public void showResponse(int id){
        if(id<resp.Length){
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
        gameObject.SetActive(true);
        manager.clearResp();
    }
    public void disableFastMoneu(){
        gameObject.SetActive(false);
    }
}
