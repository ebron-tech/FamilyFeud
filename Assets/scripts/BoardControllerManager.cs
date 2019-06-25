using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using round;

public class BoardControllerManager : MonoBehaviour
{
    Round[] rounds;
    void Awake(){
        rounds = util.getRoundsFromFolder("rounds");
    }

    
    void Update(){
        
    }
}
