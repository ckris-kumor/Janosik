using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Presets;

public class PlayerCont : MonoBehaviour
{
    [SerializeField] private Animator m_animator;
    [SerializeField] private CharacterController m_characterController;
    [SerializeField] private float jumpHeight, gravityVal;
    [Tooltip("Minimum distance Ray from bottom of capsule collider downwards extends.")] [SerializeField] private float minDist;
    [SerializeField] private float  playerYVelocity, runningSpeed, walkingSpeed, lookSensitivity;
    [SerializeField] private GameObject playerGun;
    private Vector3 RayOrigin;
    [Tooltip("Is the player on the ground?")][SerializeField] private bool isGrounded;
    RaycastHit hit;
    void Awake(){
        m_animator = gameObject.GetComponent<Animator>();
        //m_animator.applyRootMotion = true;
        m_characterController = gameObject.GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        playerGun = transform.Find("mixamorig1:Hips/mixamorig1:Spine/mixamorig1:Spine1/mixamorig1:Spine2/mixamorig1:RightShoulder/mixamorig1:RightArm/mixamorig1:RightForeArm/mixamorig1:RightHand/Musket").gameObject;
        
    }
    void Update(){
        //Shooting a Raycast in the -y dir originating from the bottom of the feet
        //The ray will only go minDist and when it hits the ground it will set isGrounded to truewww
        //Once we know if the ray has hit the ground we will let the animator controller know
        RayOrigin = new Vector3(m_characterController.bounds.center.x, m_characterController.bounds.min.y, m_characterController.bounds.center.z);
        isGrounded = Physics.Raycast(new Ray(RayOrigin, Vector3.down), out hit, minDist);
        m_animator.SetBool("isGrounded", isGrounded);
        //If we are going moving forward/backward notify the animator what dir
        m_animator.SetFloat("vertical", Input.GetAxis("Vertical") *(Input.GetButton("Run")?2.00f:1.00f));
        //Using user input to tell the animator in what direction and magnitude
        m_animator.SetFloat("horizontal", Input.GetAxis("Horizontal"));
        //Pasing mouse x dir to animator for turning player
        m_animator.SetFloat("MouseX", Input.GetAxis("Mouse X"));
        //If the user presses the crouch button tell the animator to trigger crouch 
        m_animator.SetBool("isCrouching",(Input.GetButton("Crouch")));
        //Passing the direction of our y velocity, helps the animator decide if we are jumping up, in mid air , falling
        m_animator.SetFloat("jumpDir", playerYVelocity);
        //Triggering the jumping animation in the animator by user input and whenthe player is on the ground
        if(Input.GetButtonDown("Jump") && isGrounded){
            m_animator.SetTrigger("isJumping");
            playerYVelocity += Mathf.Sqrt(jumpHeight*-1.0f*gravityVal);
        }
        //Seperate Moves to handle jump and movement
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        float playerSpeed = Input.GetButton("Run")?runningSpeed:walkingSpeed;
        //Once we land from a jump there is no point in maintaining a negative y velocity
        if(isGrounded && playerYVelocity < 0.0f)
            playerYVelocity = 0.0f;
        //regardless if we are jumping or not when we are in the air we need gravity acting on us
        playerYVelocity += gravityVal*Time.deltaTime;
        move.y = playerYVelocity;
        //have the direction of the movement localised in terms of the gameobjects local rotation
        move = transform.TransformDirection(move);
        m_characterController.Move(move*playerSpeed*Time.deltaTime);
    }
}
