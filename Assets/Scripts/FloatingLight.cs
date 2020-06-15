using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Made by James Kwon 2020.06.14
 * 
 *  Floating Light in a Sphere object for fun
 * 
 */
public class FloatingLight : MonoBehaviour
{
    public float _amplitude; // initial amplitute
    public float _speed;  // initial speed                
    private float _tempVal; // temporary y position
    private Vector3 _tempPos; // temporary position
    private bool _interupted; // interuption trigger

    void Start()
    {
        Renderer renderer = gameObject.GetComponent<Renderer>();
        renderer.material.SetColor("_Color", new Color(1.0f, 1.0f, 1.0f, 1.0f));
        _tempPos = transform.position;
        _tempVal = transform.position.y;
    }

    void Update()
    {
        if (!_interupted)
        {
            _tempPos.y = _tempVal + _amplitude * Mathf.Sin(_speed * Time.time);
            transform.position = _tempPos;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        _interupted = true;
    }
}
