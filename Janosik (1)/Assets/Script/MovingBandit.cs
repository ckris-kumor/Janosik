using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class MovingBandit : MonoBehaviour{
    //[SerializeField] private NavMeshAgent BanditMeshAgent;
    [SerializeField] private GameObject carriage;
    [SerializeField] private Transform carriageBack;
    [SerializeField] private SphereCollider banditSphere;
    [SerializeField] private Vector3 banditHideOutLoc;
    [SerializeField] private AtSpawn banditInfo;
    [SerializeField] private DepositLoot banditGold;
    [SerializeField] private Animator banditAnimator;
    [SerializeField] private float BanditSpeed;
    [SerializeField] private Rigidbody banditRB;
    // Start is called before the first frame update
    void Start(){
        carriage = GameObject.FindGameObjectWithTag("Carriage");
        carriageBack = carriage.transform.Find("WagonBack");
        banditAnimator = gameObject.GetComponent<Animator>();
        //BanditMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        banditSphere = gameObject.GetComponentInChildren<SphereCollider>();
        banditInfo = gameObject.GetComponent<AtSpawn>();
        banditHideOutLoc = GameObject.FindGameObjectWithTag("BanditBase").transform.Find("Bandit's Stash").gameObject.GetComponent<SphereCollider>().bounds.center;
        banditGold = GameObject.FindGameObjectWithTag("BanditBase").GetComponent<DepositLoot>(); 
        banditRB = gameObject.GetComponent<Rigidbody>();       
        //BanditMeshAgent.Warp(BanditBaseCollider.transform.position);

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
            if(!atCarriage)
                transform.position = Vector3.MoveTowards(gameObject.transform.position, carriageBack.position, BanditSpeed);
            else
                banditRB.velocity = Vector3.zero;
        }
        else if(atCarriage && !hasGold){
            //Debug.Log("THe Bandit has stolen gold.");
            carriage.GetComponent<CarriageGold>().StealGold();
            banditInfo.SethasGold(true);
        }
        else if(!atBase && hasGold){
            //Debug.Log("On the way back to the base.");
            transform.LookAt(banditHideOutLoc, Vector3.up);
            transform.position = Vector3.MoveTowards(transform.position, banditHideOutLoc, BanditSpeed);
        }
        else if(atBase && hasGold){
            //Debug.Log("Depositing Gold!");
            banditGold.DepositGold();
            banditInfo.SethasGold(false);
        }
        else if(atBase && !hasGold){
            //Debug.Log("Get back to the carriage!");
            transform.LookAt(carriageBack.position, Vector3.up);
            transform.position = Vector3.MoveTowards(transform.position, carriageBack.position, BanditSpeed);
        }
    }
}