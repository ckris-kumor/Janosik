using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;


namespace Com.ZiomakiStudios.Janosik{
    public class DrawNavMeshPath : MonoBehaviour{
        [SerializeField] private NavMeshAgent carriageNavAgent;
        [SerializeField] private Animator[] horseAnimators = new Animator[2];
        private int hashedIsMoving, hashedMovingSpeed;
        // Start is called before the first frame update
        public void Start(){
            carriageNavAgent = GetComponent<NavMeshAgent>();
            horseAnimators[0] = transform.Find("wagon1/Horse1").gameObject.GetComponent<Animator>();
            horseAnimators[1] = transform.Find("wagon1/Horse2").gameObject.GetComponent<Animator>();
            carriageNavAgent.destination = GameObject.FindWithTag("Map").transform.Find("EndGamePosition").position;
            hashedIsMoving = Animator.StringToHash("isMoving");
            hashedMovingSpeed = Animator.StringToHash("forwardSpeed");
        }
        // Update is called once per frame
        public void Update(){
            foreach (Animator horseAnimator in horseAnimators){
                horseAnimator.SetBool(hashedIsMoving, carriageNavAgent.speed!=0.0f);
                horseAnimator.SetFloat(hashedMovingSpeed, carriageNavAgent.speed);
            }
        }
    }
}
