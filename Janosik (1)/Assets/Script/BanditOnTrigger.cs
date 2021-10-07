using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class BanditOnTrigger : MonoBehaviour{
    [SerializeField] private Transform BanditSpawn;
    [SerializeField] private GameObject carriage;
    [SerializeField] private GameObject banditPrefab;
    [SerializeField] private AtSpawn banditInfo;
    void Start(){
        BanditSpawn = GameObject.FindGameObjectWithTag("BanditBase").transform.Find("Bandit's Stash");
        carriage = GameObject.FindGameObjectWithTag("Carriage");
        banditInfo = gameObject.GetComponent<AtSpawn>();
    }
   

    void OnCollisionEnter(Collision other){
        if (other.gameObject.CompareTag("Bullet"))
        {
            if ((banditInfo.Gethp() - 10) <= 0){
                if(banditInfo.GethasGold())
                    carriage.GetComponent<CarriageGold>().DepositGold();
                banditInfo.SethasGold(false);
                Instantiate(banditPrefab, BanditSpawn.position, Quaternion.identity);
                GameStats.killCount++;
                Destroy(gameObject);
            }
            else if ((banditInfo.Gethp() - 10) > 0){
                banditInfo.Sethp(banditInfo.Gethp() - 10);
                Debug.Log("bandit Hit , has " + banditInfo.Gethp() + " left.");
            }

        }

        
        
    }
}
