using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using round;
public class DashboardController : MonoBehaviour
{
    public Round[] rounds;
    void Awake(){
        rounds = util.getRoundsFromFolder("rounds");
    }

    void Start(){

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void instantiateSessions(){

    }
    void instantiateRounds(){

    }
    void instantiateResp(RoundElement rE){

    }
}
