using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.ZiomakiStudios.Janosik{
    public class PlayerLook : MonoBehaviour{
        #region Private Serialized Fields
        [Tooltip("What is the tag of the enemy players?")]
        [SerializeField] private string enemyTag;
        [SerializeField] private Camera m_Camera;
        [Tooltip("Sensitivity of the Mouse in the horizontal.")]
        [SerializeField] private float lookSensitivity;
        [Tooltip("Sensitivity of the Mouse in the vertical")]
        [SerializeField] private float ySensitivity;
        [Tooltip("The limit as the how much your player can look up or down.")]
        [SerializeField] private float viewRange; 
        [Tooltip("The value of FOV when the player is not 'aiming' vs and how much it is reduced when the player 'aims'.")]
        [SerializeField] private float defaultFOV, offSetFOV;
        [SerializeField] private UpdateEnemyHealth enemyHealthBarController;
        [SerializeField] private GameObject enemyHealthBar;
        [Tooltip("How far down do we want the camera to be so that the player is visible to the camera when crouching or jumping?")]
        [SerializeField] private float camOGYPos;
        [Tooltip("How much (if wanted) do we want to limit V+H look sensitivity")]
        [SerializeField] private float ADSMultiplier;
        #endregion
        private float rotY;
        private Vector3 rayOrigin;
        private RaycastHit hit;
        // Start is called before the first frame update
        void Start(){
            m_Camera = gameObject.GetComponentInChildren<Camera>();
            rotY = m_Camera.transform.eulerAngles.y;
            enemyHealthBar = transform.Find("Camera/Canvas/Enemy Health Bar").gameObject;
            enemyHealthBarController = enemyHealthBar.GetComponent<UpdateEnemyHealth>();
            camOGYPos = m_Camera.transform.position.y - transform.position.y;
        }
        // Update is called once per frame
        void Update(){
            //Zoom in effect for player "aiming down sight"
            m_Camera.fieldOfView = Input.GetButtonDown("Fire2")?(defaultFOV-offSetFOV):(Input.GetAxis("Fire2")!=0.0f?(defaultFOV-(offSetFOV*Input.GetAxis("Fire2"))):(defaultFOV));
            //have player object and camera rotate around Y axis when they are moving mouse or right jopystick at lookSensitivity degree per second * the amount
            transform.Rotate(0.0f, Input.GetAxis("Mouse X")*lookSensitivity*(m_Camera.fieldOfView!=defaultFOV?ADSMultiplier:1.00f), 0.0f, Space.World);
            ///<summary>
            ///calculating the rotation on x Axis and making sure the value that passed into the Euler func is [-viewRange, viewRange]
            ///also if the player is ADS then we are going to slow down the rate at which roty changes using ADSMultiplier [0,1]
            ///</summary>
            rotY += Input.GetAxis("Mouse Y") * ySensitivity * (m_Camera.fieldOfView!=defaultFOV?ADSMultiplier:1.00f);
            rotY = Mathf.Clamp(rotY, -viewRange, viewRange);
            //rotating just the camera on the X axis.
            m_Camera.transform.localRotation = Quaternion.Euler(rotY, 0, 0);
            //Make sure camera is at same fixed distance from the player;
            m_Camera.transform.position = new Vector3(m_Camera.transform.position.x, (m_Camera.transform.position.y-transform.position.y!=camOGYPos)?(transform.position.y+camOGYPos):m_Camera.transform.position.y,m_Camera.transform.position.z);
            //Firing raycast through middle of screen , ideally crosshair ui should be at the same position on the player camera's vewport
            rayOrigin = m_Camera.ViewportToWorldPoint(new Vector3(0.5f,0.5f,0.0f));
            if(Physics.Raycast(rayOrigin, m_Camera.transform.forward.normalized, out hit)){
                //If the obj in our LOS is an enemy player and not our player potentially blocking our LOS
                if(hit.transform.CompareTag(enemyTag) && hit.transform.gameObject != gameObject){
                    enemyHealthBar.SetActive(true);
                    enemyHealthBar.transform.position = m_Camera.WorldToScreenPoint(hit.transform.Find("HealthBarLoc").position);
                    enemyHealthBarController.ShowEnemyHealth(hit.transform.name, hit.transform.gameObject.GetComponent<PlayerInfo>().Gethp());
                }
                else
                    enemyHealthBar.SetActive(false);
            }
            else
                enemyHealthBar.SetActive(false);
        }
    }
}
