using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace Com.ZiomakiStudios.Janosik{
    public class MovingBandit : MonoBehaviour{
        //[SerializeField] private NavMeshAgent banditMeshAgent;
        [SerializeField] private GameObject carriage;
        [SerializeField] private Transform carriageBack;
        [SerializeField] private SphereCollider banditSphere;
        [SerializeField] private Vector3 banditHideOutLoc;
        [SerializeField] private PlayerInfo banditInfo;
        [SerializeField] private DepositLoot banditGold;
        [SerializeField] private Animator banditAnimator;
        [SerializeField] private Rigidbody banditRB;
        // Start is called before the first frame update
        void Start(){
            carriage = ObjectPool.SharedInstance.GetPooledObject(3);
            carriageBack = carriage.transform.Find("PromptInteractLoc");
            banditAnimator = gameObject.GetComponent<Animator>();
        //banditMeshAgent = gameObject.GetComponent<NavMeshAgent>();
            banditSphere = gameObject.GetComponentInChildren<SphereCollider>();
            banditInfo = gameObject.GetComponent<PlayerInfo>();
            banditHideOutLoc = GameObject.FindGameObjectWithTag("BanditBase").transform.Find("Bandit's Stash").gameObject.GetComponent<SphereCollider>().bounds.center;
            banditGold = GameObject.FindGameObjectWithTag("BanditBase").GetComponentInChildren<DepositLoot>(); 
            banditRB = gameObject.GetComponent<Rigidbody>();       
            
        }
        // Update is called once per frame
        void Update(){
            banditAnimator.SetFloat("forwardSpeed", Mathf.Abs(transform.forward.z));
            banditAnimator.SetFloat("turnSpeed", transform.forward.x);
            bool atCarriage = banditSphere.bounds.Contains(carriageBack.position);
            bool atBase = banditSphere.bounds.Contains(banditHideOutLoc);
            bool hasGold = banditInfo.GethasGold();
            if(!atCarriage && !hasGold){
                //Debug.Log("We are moving toward the carriage.");
                transform.LookAt(carriageBack.position, Vector3.up);
                //banditMeshAgent.destination = carriageBack.position;
            }
            else if(atCarriage && !hasGold){
                //Debug.Log("THe Bandit has stolen gold.");
                carriage.GetComponent<CarriageGold>().StealGold();
                banditInfo.SethasGold(true);
            }
            else if(!atBase && hasGold){
                //Debug.Log("On the way back to the base.");
                transform.LookAt(banditHideOutLoc, Vector3.up);
                //banditMeshAgent.destination = banditHideOutLoc;
            }
            else if(atBase && hasGold){
                //Debug.Log("Depositing Gold!");
                banditGold.DepositGold();
                banditInfo.SethasGold(false);
            }
            else if(atBase && !hasGold){
                //Debug.Log("Get back to the carriage!");
                transform.LookAt(carriageBack.position, Vector3.up);
                //banditMeshAgent.destination = carriageBack.position;
            }
        }
    }
}