using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DepositLoot : MonoBehaviour{
    [SerializeField] private SphereCollider LootDetectionVolume;
    [SerializeField] private GameObject[] players;
    [SerializeField] private Text PlayerPrompt;
    [SerializeField] private UpdateBanditsGold banditsGold;
    

    public void Start(){
        players = GameObject.FindGameObjectsWithTag("Player");
        banditsGold = GetComponent<UpdateBanditsGold>();
        
    }

    // Update is called once per frame
    public void Update(){
        foreach (GameObject player in players){ 
            PlayerPrompt = player.GetComponentInChildren<Text>();
            banditsGold = player.GetComponentInChildren<UpdateBanditsGold>();
            if (LootDetectionVolume.bounds.Contains(player.transform.position)){
                bool hasGold = player.GetComponent<AtSpawn>().GethasGold();
                if (player.CompareTag("Bandit") && hasGold){
                    PlayerPrompt.text = "Press E to stash gold.";
                    PlayerPrompt.enabled = true;
                    player.GetComponent<AtSpawn>().SethasGold(false);
                    PlayerPrompt.enabled = false;
                }
                else if (player.transform.Find("PlayerBody").CompareTag("Guard")  && !(hasGold) &&(banditsGold.GetnumGold() != 0)){
                    PlayerPrompt.text = "Press E to steal Bandit's gold.";
                    PlayerPrompt.enabled = true;
                    if (Input.GetButtonDown("Interact")){
                        player.GetComponent<AtSpawn>().SethasGold(true);
                        PlayerPrompt.enabled = false;
                    }

                }
            } 
        }
    }
}
