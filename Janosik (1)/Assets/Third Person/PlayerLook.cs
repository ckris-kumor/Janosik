using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour{
    [SerializeField] private Camera m_Camera;
    [Tooltip("Sensitivity of the Mouse in the horizontal.")]
    [SerializeField] private float lookSensitivity;
    [Tooltip("Sensitivity of the Mouse in the vertical")]
    [SerializeField] private float ySensitivity;
    [Tooltip("The limit as the how much your player can look up or down.")]
    [SerializeField] private float viewRange;
    [SerializeField] private UpdateEnemyHealth enemyHealthBarController;
    [SerializeField] private GameObject enemyHealthBar;
    private float rotY;
    private Vector3 rayOrigin;
    private RaycastHit hit;
    // Start is called before the first frame update
    void Start(){
        m_Camera = gameObject.GetComponentInChildren<Camera>();
        rotY = m_Camera.transform.eulerAngles.y;
        enemyHealthBar = transform.Find("Camera/Canvas/Enemy Health Bar").gameObject;
        enemyHealthBarController = enemyHealthBar.GetComponent<UpdateEnemyHealth>();
    }
    // Update is called once per frame
    void Update(){
        //have player object and camera rotate around Y axis when they are moving mouse or right jopystick at lookSensitivity degree per second * the amount
        transform.Rotate(0.0f, Input.GetAxis("Mouse X")*lookSensitivity, 0.0f, Space.World);
        //calculating the rotation on x Axis and making sure the value that passed into the Euler func is [-viewRange, viewRange]
        rotY += Input.GetAxis("Mouse Y") * ySensitivity;
        rotY = Mathf.Clamp(rotY, -viewRange, viewRange);
       //rotating just the camera on the X axis.
        m_Camera.transform.localRotation = Quaternion.Euler(rotY, 0, 0);
        rayOrigin = m_Camera.ViewportToWorldPoint(new Vector3(0.5f,0.5f,0.0f));
        if(Physics.Raycast(rayOrigin, m_Camera.transform.forward.normalized, out hit)){
            if(hit.transform.CompareTag("Player")){
                enemyHealthBar.SetActive(true);
                enemyHealthBar.transform.position = m_Camera.WorldToScreenPoint(hit.transform.Find("HealthBarLoc").position);
                enemyHealthBarController.ShowEnemyHealth(hit.transform.name, hit.transform.gameObject.GetComponent<AtSpawn>().Gethp());
            }
            else
                enemyHealthBar.SetActive(false);
                
        }
        else
            enemyHealthBar.SetActive(false);

    }
}
