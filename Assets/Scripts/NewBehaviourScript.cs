using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    
    private Animator fabiansAnimator;
    // Start is called before the first frame update
    void Start()
    {
        fabiansAnimator = GetComponent<Animator>();
        
        fabiansAnimator.SetBool("Run", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("a") || Input.GetKeyDown("d"))
        {
            fabiansAnimator.SetBool("Run", true);
        }
        
        if (Input.GetKeyUp("a") || Input.GetKeyUp("d"))
        {
            fabiansAnimator.SetBool("Run", false);
        }
    } 
}
