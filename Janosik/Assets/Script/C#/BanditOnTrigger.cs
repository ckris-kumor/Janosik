using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace Com.ZiomakiStudios.Janosik{
    public class BanditOnTrigger : MonoBehaviour{
        #region Private Serialized Fields
        [SerializeField] private Transform BanditSpawn, banditHead;
        [SerializeField] private GameObject carriage;
        [SerializeField] private GameObject banditPrefab;
        [SerializeField] private PlayerInfo banditInfo;
        [Tooltip("How for from the center of the head can we consider a bulletHit a headshot?")]
        [SerializeField] private float minDist;
        #endregion
        private CarriageGold carriageGold;
        void Start(){
            //Gathered and stored references to locations pf interest, stats on bandit, places bandit can be hit bgy bullet, etc...
            BanditSpawn = GameObject.FindGameObjectWithTag("BanditBase").transform.Find("Bandit's Stash");
            carriage = ObjectPool.SharedInstance.GetActiveObject(2);
            banditInfo = gameObject.GetComponent<PlayerInfo>();
            banditHead = transform.Find("EthanSkeleton/EthanHips/EthanSpine/EthanSpine1/EthanSpine2/EthanNeck/EthanHead/HeadDetectorLoc");
            carriageGold = carriage.GetComponent<CarriageGold>();
        }
        public void HitByBullet(float gunDamage, Vector3 hitPoint){
            //When the bandit is hit by the another players LOS and that player has fire a bullet, do actions bellow to account for damage this bandit will take
            float damage = (Vector3.Distance(banditHead.position,hitPoint)<=minDist)?gunDamage*2.0f:gunDamage;
            //If the Bandit diesfrom this hit
            if ((banditInfo.Gethp() - damage) <= 0){
                //Deposit their gold back to the carriage if they have any, subject to change
                if(banditInfo.GethasGold())
                    carriageGold.DepositGold();
                //banditInfo.SethasGold(false);
                //Update the given the local players kill count
                GameStats.killCount++;
                //make sure the current bandit that has died becomes deactivated and can be repurposed
                gameObject.SetActive(false);
                //find unused bandit AI on object pool
                GameObject newBandit = ObjectPool.SharedInstance.GetPooledObject(0);
                if(newBandit != null){
                    //spawn said bandit at base
                    newBandit.transform.position = BanditSpawn.position;
                    newBandit.transform.rotation = Quaternion.identity;
                    //make sure it not seen as a object that repurposed while in use
                    newBandit.SetActive(true);
                }
                //delete temp vars tie to reference
                newBandit = null;
            }
            else
                //If this bullet does not kill use then apply appropriate damage to bandits health
                banditInfo.Sethp(banditInfo.Gethp() - damage);
        }
    }
}
