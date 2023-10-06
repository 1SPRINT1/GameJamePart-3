using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarMove : MonoBehaviour
{
    public Transform SelfTransform;
        private Vector3 _force;
    void Start()
    {
        
    }

    
    void Update()
    {
        SelfTransform.position += _force;

        if (Input.GetKey(KeyCode.W))
        {
            _force += (SelfTransform.up * Time.deltaTime) * 0.15f;
        }
        else
        {
            _force = Vector3.Lerp(_force, Vector3.zero, Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            _force -= (SelfTransform.up * Time.deltaTime) * 0.1f;
        }
        else
        {
            _force = Vector3.Lerp(_force, Vector3.zero, Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            SelfTransform.Rotate(0, 0, 0.5f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            SelfTransform.Rotate(0, 0, -0.5f);
        }
    }
}
