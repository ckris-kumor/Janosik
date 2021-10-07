using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectLooter : MonoBehaviour{
    
    [SerializeField] private AtSpawn playerAtSpawn;
    private Text playerPromptText;
    [SerializeField] private MaintainLootChest chestController;
    [SerializeField] private SphereCollider chestCollider;
    [SerializeField] private GameObject[] players;
    void Start(){
        chestController = gameObject.transform.parent.gameObject.GetComponent<MaintainLootChest>(); 
        chestCollider = gameObject.GetComponent<SphereCollider>();
        players  = GameObject.FindGameObjectsWithTag("Player");
    }
    void Update(){
        if(players.Length == 0)
            players  = GameObject.FindGameObjectsWithTag("Player");
        foreach(GameObject player in players){
            playerAtSpawn = player.GetComponent<AtSpawn>();
            playerPromptText = player.GetComponentInChildren<Text>();
            if(chestCollider.bounds.Contains(player.transform.position) && !playerAtSpawn.hasGold && player.transform.Find("PlayerBody").tag == "Guard"){
                playerPromptText.enabled = true;
                if(Input.GetButtonDown("Interact")){
                    Debug.Log("We are stealing Gold!");
                    chestController.stealGold();
                    playerAtSpawn.hasGold = true;
                    playerPromptText.enabled = false;

                }
            }    
        }
    }
}
