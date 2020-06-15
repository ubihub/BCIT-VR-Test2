using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* made bu James Kwon 2020.06.14
 * 
 * To contol hand grab action responce
 * 
 */

public class HandAnimation : MonoBehaviour
{

    private Animator _anim;
    private HandGrabbing _handGrab;

    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _handGrab = GetComponent<HandGrabbing>();
    }

    void Update()
    {
        //if player is pressing grab, set animator bool IsGrabbing to true
        if (Input.GetAxis(_handGrab.InputName) >= 0.01f)
        {
            if (!_anim.GetBool("IsGrabbing"))
            {
                _anim.SetBool("IsGrabbing", true);
            }
        }
        else
        {
            //if player lets go of grab, set IsGrabbing to false
            if (_anim.GetBool("IsGrabbing"))
            {
                _anim.SetBool("IsGrabbing", false);
            }
        }

    }
}
