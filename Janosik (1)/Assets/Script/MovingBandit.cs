using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class MovingBandit : MonoBehaviour
{
    
    NavMeshAgent BanditMeshAgent;
    GameObject Bandit;
    GameObject carriage;
    SphereCollider CarriagePlayerDetection;
    SphereCollider BanditBaseCollider;
    public Text BanditGoldText;
    float BanditSpeed;
    
        // Start is called before the first frame update
    public void Start()
    {
        Bandit = GameObject.FindGameObjectWithTag("Bandit");
        carriage = GameObject.FindGameObjectWithTag("Carriage");
        BanditMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        CarriagePlayerDetection = carriage.GetComponent<SphereCollider>();
        BanditBaseCollider = GameObject.FindGameObjectWithTag("BanditBase").GetComponent<SphereCollider>();
        BanditGoldText = GameObject.FindGameObjectWithTag("BanditGoldTextField").GetComponent<Text>();        
        //BanditMeshAgent.Warp(BanditBaseCollider.transform.position);
        BanditSpeed = BanditMeshAgent.speed * 0.1f;

    }
    // Update is called once per frame
   public void Update()
    {
        //Debug.Log(CarriagePlayerDetection.bounds.Contains(Bandit.transform.position));
        if(!(CarriagePlayerDetection.bounds.Contains(Bandit.transform.position)) && !(Bandit.GetComponent<AtSpawn>().GethasGold()))
        {
            //Debug.Log("We are moving toward the carriage.");
            Bandit.transform.LookAt(carriage.transform.position, Vector3.up);
            Bandit.transform.position = Vector3.MoveTowards(Bandit.transform.position, carriage.transform.position, BanditSpeed);
            
        }

        else if (CarriagePlayerDetection.bounds.Contains(Bandit.transform.position) && !(Bandit.GetComponent<AtSpawn>().GethasGold()))
        {
            //Debug.Log("THe Bandit has stolen gold.");
            carriage.GetComponent<CarriageGold>().StealGold();
            Bandit.GetComponent<AtSpawn>().SethasGold(true);


        }

        else if (!(CarriagePlayerDetection.bounds.Contains(gameObject.transform.position)) && (Bandit.GetComponent<AtSpawn>().GethasGold())&& !(BanditBaseCollider.bounds.Contains(Bandit.transform.position)))
        {
            //Debug.Log("On the way back to the base.");
            Bandit.transform.LookAt(BanditBaseCollider.transform.position, Vector3.up);
            Bandit.transform.position = Vector3.MoveTowards(Bandit.transform.position, BanditBaseCollider.transform.position, BanditSpeed);
            
        }

        else if(!(CarriagePlayerDetection.bounds.Contains(gameObject.transform.position)) && (Bandit.GetComponent<AtSpawn>().GethasGold()) && (BanditBaseCollider.bounds.Contains(Bandit.transform.position)))
        {
            //Debug.Log("Depositing Gold!");
            BanditGoldText.GetComponent<UpdateBanditsGold>().DepositGold();
            Bandit.GetComponent<AtSpawn>().SethasGold(false);
        }

        else if (!(CarriagePlayerDetection.bounds.Contains(gameObject.transform.position)) && (BanditBaseCollider.bounds.Contains(gameObject.transform.position))  && !(Bandit.GetComponent<AtSpawn>().GethasGold()))
        {
            //Debug.Log("Get back to the carriage!");
            Bandit.transform.LookAt(carriage.transform.position, Vector3.up);
            Bandit.transform.position = Vector3.MoveTowards(Bandit.transform.position, carriage.transform.position, BanditSpeed);
            
            
        }



    }
}