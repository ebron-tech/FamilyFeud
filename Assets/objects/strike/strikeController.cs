using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class strikeController : MonoBehaviour
{
    // Start is called before the first frame update
    public strikeObj strikeL,strikeC,strikeR;
    void Start()
    {
        strikeR.gameObject.SetActive(false);
        strikeC.gameObject.SetActive(false);
        strikeL.gameObject.SetActive(false);
    }

    public void triggerStrike(int countStrikes){
        switch(countStrikes){
            case 1:
                strikeC.triggerAnimation();
            break;
            case 2:
                strikeR.triggerAnimation();
                strikeL.triggerAnimation();
                break;
            case 3:
                strikeR.triggerAnimation();
                strikeC.triggerAnimation();
                strikeL.triggerAnimation();
                break;
            default:
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
