using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour{
    [SerializeField] private Camera m_Camera;
    [SerializeField] private float lookSensitivity, ySensitivity;
    private float rotY;
    
    // Start is called before the first frame update
    void Start(){
        m_Camera = gameObject.GetComponentInChildren<Camera>();
        rotY = 0.0f;
    }
    

    // Update is called once per frame
    void Update(){
        //have object rotate around Y axis when they are moving mouse or right jopystick at lookSensitivity degree per second * the amount
        transform.Rotate(0.0f, Input.GetAxis("Mouse X"), 0.0f, Space.World);
        m_Camera.transform.Rotate(Mathf.Clamp(Input.GetAxis("Mouse Y")*ySensitivity, -.5f, .5f), 0.0f, 0.0f, Space.Self);
        

    }
}
