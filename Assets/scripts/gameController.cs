using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using round;
public class gameController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Round[] rounds = util.getRoundsFromFolder("rounds");
		foreach(Round r in rounds){
			foreach(RoundElement re in r.Rounds){
			Debug.Log(re.Question);
			
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
