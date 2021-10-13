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
        players  = ObjectPool.SharedInstance.GetPooledObjects(2);
    }
    void Update(){
        foreach(GameObject player in players){
            if(player.activeInHierarchy){
                if(chestCollider.bounds.Contains(player.transform.position) && !playerAtSpawn.hasGold && player.transform.Find("PlayerBody").tag == "Guard"){
                    playerPromptText = player.GetComponentInChildren<Text>();
                    playerPromptText.enabled = true;
                    if(Input.GetButtonDown("Interact")){
                        Debug.Log("We are stealing Gold!");
                        chestController.stealGold();
                        player.GetComponent<AtSpawn>().hasGold = true;
                        playerPromptText.enabled = false;
                    }
                }
            } 
        }
    }
}
