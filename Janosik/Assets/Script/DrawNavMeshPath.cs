using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;



public class DrawNavMeshPath : MonoBehaviour{
    [SerializeField] private NavMeshAgent carriageNavAgent;
    [SerializeField] private Animator[] horseAnimators = new Animator[2];
    // Start is called before the first frame update
    public void Start(){
        carriageNavAgent = GetComponent<NavMeshAgent>();
        horseAnimators[0] = transform.Find("wagon1/Horse1").gameObject.GetComponent<Animator>();
        horseAnimators[1] = transform.Find("wagon1/Horse2").gameObject.GetComponent<Animator>();
        carriageNavAgent.destination = GameObject.FindWithTag("Map").transform.Find("EndGamePosition").position;
    }
    // Update is called once per frame
    public void Update(){
        foreach (Animator horseAnimator in horseAnimators){
            horseAnimator.SetBool("isMoving", carriageNavAgent.speed!=0.0f);
            horseAnimator.SetFloat("forwardSpeed", carriageNavAgent.speed);
        }
    }
}
