using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Made by James Kwon 2020.06.14
 * 
 * controlls the door lock by the eular angles and rotation angles of the door panel and the door handle with offsets
 * 
 */

public class UnlockDoor : MonoBehaviour
{
    public GameObject _parent;
    public GameObject _child;
    public float _handle_angleX;
    public float _handle_angleY;
    public float _handle_angleZ;
    public float _panel_angleX;
    public float _panel_angleY;
    public float _panel_angleZ;
    public float _offset1;
    public float _offset2;

    private bool unlocked;

    void Start()
    {

    }

    private void Awake()
    {

    }

    // checks the eular angles and rotation angles of the door panel and the door handle
    void Update()
    {
        if (! unlocked && _child.transform.eulerAngles.x > _offset2 && _child.transform.eulerAngles.x < _handle_angleX )
        {
            Unlock();
            unlocked = true;
        }
        else if (unlocked && (_child.transform.eulerAngles.x > _offset1 || _child.transform.eulerAngles.x < _offset2) &&
            _parent.transform.rotation.y > _panel_angleY && _child.transform.eulerAngles.y > _handle_angleY )
        {
            Lock();
            unlocked = false;
        }
    }


    // Animation is the future extension.
    private void Unlock()
    {
        AudioSource door_sound = _child.GetComponent<AudioSource>();
        door_sound.Play();
        Rigidbody door_panel = _parent.GetComponent<Rigidbody>();
        door_panel.constraints = RigidbodyConstraints.None;
        door_panel.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ ;
        Animator door_panel_animator = _parent.GetComponent<Animator>();
        door_panel_animator.SetTrigger("isOpening");
    }

    private void Lock()
    {
        AudioSource door_sound = _child.GetComponent<AudioSource>();
        door_sound.Play();
        Rigidbody door_panel = _parent.GetComponent<Rigidbody>();
        door_panel.constraints = RigidbodyConstraints.FreezeAll;
    }
}
