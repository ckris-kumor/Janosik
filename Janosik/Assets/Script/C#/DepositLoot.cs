using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Com.ZiomakiStudios.Janosik{
    public class DepositLoot : MonoBehaviour{
        #region Private Serialized Fields
        [SerializeField] private SphereCollider LootDetectionVolume;
        [SerializeField] private List<GameObject> players;
        [SerializeField] private Text PlayerPrompt;
        [SerializeField] private int numGold;
        [SerializeField] private PlayerInfo playerInfo;
        #endregion
        #region Public Gold Manip Funcs
        public int GetNumGold(){
            return numGold;
        }
        public void DepositGold(){
            numGold++;

        }
        public void WithdrawGold(){

            numGold--;

        }
        #endregion
        public void Start(){
            players = ObjectPool.SharedInstance.GetActiveObjects(2);
        }
        // Update is called once per frame
        public void Update(){
            players = ObjectPool.SharedInstance.GetActiveObjects(2);
            foreach (GameObject player in players){ 
                PlayerPrompt = player.GetComponentInChildren<Text>();
                playerInfo = player.GetComponent<PlayerInfo>();
                if (LootDetectionVolume.bounds.Contains(player.transform.position)){
                    bool hasGold = playerInfo.GethasGold();
                    if (player.CompareTag("Bandit") && hasGold){
                        PlayerPrompt.text = "Press E to stash gold.";
                        PlayerPrompt.enabled = true;
                        playerInfo.SethasGold(false);
                        numGold++;
                        PlayerPrompt.enabled = false;
                    }
                    else if (player.CompareTag("Guard")  && !(hasGold) &&(numGold != 0)){
                        PlayerPrompt.text = "Press E to steal Bandit's gold.";
                        PlayerPrompt.enabled = true;
                        if (Input.GetButtonDown("Interact")){
                            playerInfo.SethasGold(true);
                            numGold--;
                            PlayerPrompt.enabled = false;
                        }
                    }
                } 
            }
        }
    }
}
