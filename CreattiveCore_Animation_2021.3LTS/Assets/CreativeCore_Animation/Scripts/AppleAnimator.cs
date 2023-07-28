using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleAnimator : MonoBehaviour
{
    public Animator anim;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetTrigger("Rotating_X_Trigger");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetTrigger("Rotating_Y_Trigger");
        }
    }
}
