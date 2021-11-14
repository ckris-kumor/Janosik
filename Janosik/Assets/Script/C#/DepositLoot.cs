using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DepositLoot : MonoBehaviour{
    [SerializeField] private SphereCollider LootDetectionVolume;
    [SerializeField] private List<GameObject> players;
    [SerializeField] private Text PlayerPrompt;
    [SerializeField] private int numGold;
    public void Start(){
        players = ObjectPool.SharedInstance.GetActiveObjects(2);
        numGold = 0;
    }
    public int GetNumGold(){
        return numGold;
    }
    public void DepositGold(){
        numGold++;
    }
    public void WithdrawGold(){
        numGold--;
    }
    // Update is called once per frame
    public void Update(){
        players = ObjectPool.SharedInstance.GetActiveObjects(2);
        foreach (GameObject player in players){ 
            PlayerPrompt = player.GetComponentInChildren<Text>();
            if (LootDetectionVolume.bounds.Contains(player.transform.position)){
                bool hasGold = player.GetComponent<AtSpawn>().GethasGold();
                if (player.transform.Find("PlayerBody").CompareTag("Bandit") && hasGold){
                    PlayerPrompt.text = "Press E to stash gold.";
                    PlayerPrompt.enabled = true;
                    player.GetComponent<AtSpawn>().SethasGold(false);
                    numGold++;
                    PlayerPrompt.enabled = false;
                }
                else if (player.transform.Find("PlayerBody").CompareTag("Guard")  && !(hasGold) &&(numGold != 0)){
                    PlayerPrompt.text = "Press E to steal Bandit's gold.";
                    PlayerPrompt.enabled = true;
                    if (Input.GetButtonDown("Interact")){
                        player.GetComponent<AtSpawn>().SethasGold(true);
                        numGold--;
                        PlayerPrompt.enabled = false;
                    }
                }
            } 
        }
    }
}
