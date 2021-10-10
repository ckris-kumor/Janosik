using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;



public class DrawNavMeshPath : MonoBehaviour{
    [SerializeField] private NavMeshAgent carriageNavAgent;
    [SerializeField] private Animator horseAnimator;

    


    
    // Start is called before the first frame update
    public void Start(){
        carriageNavAgent = GetComponent<NavMeshAgent>();
        horseAnimator = transform.Find("Horse").gameObject.GetComponent<Animator>();
        carriageNavAgent.destination = GameObject.FindWithTag("Map").transform.Find("EndGamePosition").position;
        transform.right = transform.TransformDirection(carriageNavAgent.velocity.normalized);
    }

    // Update is called once per frame
    public void Update(){
        horseAnimator.SetBool("isMoving", carriageNavAgent.speed!=0.0f);
        horseAnimator.SetFloat("forwardSpeed", carriageNavAgent.speed);
        
    }
}
