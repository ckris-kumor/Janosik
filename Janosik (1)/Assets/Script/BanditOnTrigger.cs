using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class BanditOnTrigger : MonoBehaviour{
    [SerializeField] private Transform BanditSpawn, banditHead;
    [SerializeField] private GameObject carriage;
    [SerializeField] private GameObject banditPrefab;
    [SerializeField] private AtSpawn banditInfo;
    [Tooltip("How for from the center of the head can we consider a bulletHit a headshot?")]
    [SerializeField] private float minDist;
    private CarriageGold carriageGold;
    void Start(){
        //Gathered and stored references to locations pf interest, stats on bandit, places bandit can be hit bgy bullet, etc...
        BanditSpawn = GameObject.FindGameObjectWithTag("BanditBase").transform.Find("Bandit's Stash");
        carriage = GameObject.FindGameObjectWithTag("Carriage");
        banditInfo = gameObject.GetComponent<AtSpawn>();
        banditHead = transform.Find("EthanSkeleton/EthanHips/EthanSpine/EthanSpine1/EthanSpine2/EthanNeck/EthanHead/HeadDetectorLoc");
        carriageGold = carriage.GetComponent<CarriageGold>();
    }
    public void HitByBullet(float gunDamage, Vector3 hitPoint){
        //When the bandit is hit by the another players LOS and that player has fire a bullet, do actions bellow to account for damage this bandit will take
        float damage = (Vector3.Distance(banditHead.position,hitPoint)<=minDist)?gunDamage*2.0f:gunDamage;
        //If the Bandit dies then have its gold deposited back into the carriage, subject to change in the future.
        if ((banditInfo.Gethp() - damage) <= 0){
            if(banditInfo.GethasGold())
                carriageGold.DepositGold();
            banditInfo.SethasGold(false);
            GameStats.killCount++;
            Instantiate(banditPrefab, BanditSpawn.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if ((banditInfo.Gethp() - damage) > 0)
            banditInfo.Sethp(banditInfo.Gethp() - (int)damage);
    }
}
