using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualBoard : MonoBehaviour
{
    // Start is called before the first frame update
    public TMPro.TextMeshPro currentPoints, leftPoints,rightPoints;
    int cPoints,lPoints,rPoints;
    void Start()
    {
        updateCurrentPoints(0);
        updateLeftPoints(0);
        updateRightPoints(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void updateCurrentPoints(int p){
        cPoints=p;
        currentPoints.text=p+"";
    }
    public void updateRightPoints(int p){
        rPoints = p;
        rightPoints.text=p+"";
    }
    public void updateLeftPoints(int p){
        lPoints =p;
        leftPoints.text=p+"";
    }
}
