using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatedPlayer : MonoBehaviour
{
    private Animator alexAnimator;
    
    // Start is called before the first frame update
    void Start()
    {
        alexAnimator = GetComponent<Animator>();
        
        alexAnimator.SetBool("start", false);
        alexAnimator.SetBool("stop", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("d"))
        {
            alexAnimator.SetBool("start",true);
            alexAnimator.SetBool("stop",false);
        }
        if (Input.GetKeyUp("d"))
        {
            alexAnimator.SetBool("start",false);
            alexAnimator.SetBool("stop",true);
        }
    }
}
