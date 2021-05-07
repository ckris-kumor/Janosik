using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class BanditOnTrigger : MonoBehaviour
{
    GameObject Bandit;
    SphereCollider BanditSpawn;
    GameObject carriage;
   

    public void OnCollisionEnter(Collision other)
    {
        BanditSpawn = GameObject.FindGameObjectWithTag("BanditBase").GetComponent<SphereCollider>();
        carriage = GameObject.FindGameObjectWithTag("Carriage");


        if (other.gameObject.CompareTag("Bullet"))
        {
            if ((gameObject.GetComponent<AtSpawn>().Gethp() - 10) <= 0)
            {
                gameObject.GetComponent<AtSpawn>().Sethp(100);
                if(gameObject.GetComponent<AtSpawn>().GethasGold())
                {
                    carriage.GetComponent<CarriageGold>().DepositGold();
                }
                gameObject.GetComponent<AtSpawn>().SethasGold(false);
                
                gameObject.GetComponent<NavMeshAgent>().Warp(BanditSpawn.transform.position);
                GameStats.killCount++;
            }


            else if (gameObject.CompareTag("Bandit") && ((gameObject.GetComponent<AtSpawn>().Gethp() - 10) > 0))
            {
                gameObject.GetComponent<AtSpawn>().Sethp(gameObject.GetComponent<AtSpawn>().Gethp() - 10);
                Debug.Log("bandit Hit , has " + gameObject.GetComponent<AtSpawn>().Gethp() + " left.");
            }

        }

        
        
    }
}
