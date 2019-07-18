using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionsButton : MonoBehaviour
{

    public TMPro.TextMeshProUGUI txtSessionName;
    public string sessionName;
    public int sessionId;
    DashboardController controller;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void init(int id, string name, DashboardController dc){
        sessionId = id;
        sessionName = name;
        controller = dc;
        txtSessionName.text=name;
    }

    
}
