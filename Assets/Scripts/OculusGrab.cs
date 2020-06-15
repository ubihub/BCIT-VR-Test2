using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

/* made by James Kwon 2020.06.14
 * 
 * To controll the Oculus controller grab action
 * 
 */

public class OculusGrab : MonoBehaviour
{


    public GameObject _collidingObject;
    public GameObject _objectInHand;
    Animator _animatior;
    Animator _animatior_panel;
    Quaternion _previousRotation , _nextRotation;
    bool _isFirstTime = true;
    bool _isRoatating = false;


    // trigger functions after adding trigger zones to controllers and adding script to controllers
    public void OnTriggerEnter(Collider other) //picking up objects with rigidbodies
    {

        if (other.gameObject.GetComponent<Rigidbody>())
        {
            _collidingObject = other.gameObject;
            //get the Animator attached to the GameObject you are intending to animate.
            _animatior = other.gameObject.GetComponent<Animator>();
            _animatior.SetTrigger("isGrabbing");
        }

    }

    public void OnTriggerExit(Collider other)
    {

        _collidingObject = other.gameObject;
        _animatior = other.gameObject.GetComponent<Animator>();
        _animatior.ResetTrigger("isGrabbing");
        _collidingObject = null;

    }

    void Update() // refreshing program confirms trigger pressure and determines whether holding or releasing object
    {
        float distance = Input.GetAxis("Oculus_CrossPlatform_PrimaryHandTrigger");
        if (distance > 0.0f) { 
            if (distance > 0.002f && _collidingObject)
                GrabObject();
            else
                ReleaseObject();
        }
        CheckRotating();
    }

    private void CheckRotating()
    {
        _nextRotation = gameObject.transform.parent.gameObject.transform.rotation;
        if (_isFirstTime)
        {
            _previousRotation = _nextRotation;
            _isFirstTime = false;
        }
        else if (Quaternion.Angle(_previousRotation, _nextRotation) > 0.0f)
        {
            _isRoatating = true;
            _previousRotation = _nextRotation;
            Debug.Log("IsRotating = true");
            return;
        }
        _isRoatating = false;
        Debug.Log("IsRotating = false");
        return;
    }


    public void GrabObject() //create parentchild relationship between object and hand so object follows hand
    {
        _objectInHand = _collidingObject;
        _objectInHand.transform.SetParent(this.transform);
        _objectInHand.GetComponent<Rigidbody>().isKinematic = true;

    }


    private void ReleaseObject() //removing parentchild relationship so you drop the object
    {
        _objectInHand.GetComponent<Rigidbody>().isKinematic = false;
        _objectInHand.transform.SetParent(null);
        _objectInHand = null;
    }

}