using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Made by James Kwon 2020.06.14
 * 
 * To show Transformation on the prompt guide to detection of angles of the door panel and door handle
 * 
 */

public class TransformDetector : MonoBehaviour
{
    public GameObject _parent;
    public GameObject _child;
    private TextMesh _infoText;
    private string _infoString;
    string _original_info_text;

    void Start()
    {
        _infoText = gameObject.GetComponent<TextMesh>();
        _original_info_text = _infoText.text + "\n";

    }

    void Update()
    {
        string handleEularAngleX;
        string handleEularAngleY;
        string handleEularAngleZ;
        string panelRotationX;
        string panelRotationY;
        string panelRotationZ;

        handleEularAngleX = _child.transform.eulerAngles.x.ToString();
        handleEularAngleY = _child.transform.eulerAngles.y.ToString();
        handleEularAngleZ = _child.transform.eulerAngles.z.ToString();
        panelRotationX = _parent.transform.rotation.x.ToString();
        panelRotationY = _parent.transform.rotation.y.ToString();
        panelRotationZ = _parent.transform.rotation.z.ToString();


        _infoString = "";
        _infoString += "\n";
        _infoString += "Handle EularX : " + handleEularAngleX + "\n";
        _infoString += "Handle EularY : " + handleEularAngleY + "\n";
        _infoString += "Handle EularZ : " + handleEularAngleZ + "\n";
        _infoString += "Panel RotationX : " + panelRotationX + "\n";
        _infoString += "Panel RotationY : " + panelRotationY + "\n";
        _infoString += "Panel RotationZ : " + panelRotationZ + "\n";
        _infoText.text = _original_info_text + _infoString;

    }
}
