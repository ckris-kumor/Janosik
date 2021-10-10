using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CarriageGold : MonoBehaviour
{
    [Tooltip("This collider will detect if the player is a the immediate area of the carriage.")]
    [SerializeField] private SphereCollider carriageCollider;
    [SerializeField] private GameObject[] players;
    [SerializeField] private int goldAmmount;
    [SerializeField] private Text PlayerPrompt;
    [SerializeField] private AtSpawn playerInfo;
    public float GetGoldAmnt(){
        return goldAmmount;
    }
    public void SetGoldAmnt(int ammount){
        this.goldAmmount = ammount;
    }
    public void StealGold(){
        this.goldAmmount -= 1;
    }
    public void DepositGold(){
        this.goldAmmount += 1;
    }
    public void Start(){
        SetGoldAmnt(4);
        carriageCollider = gameObject.GetComponentInChildren<SphereCollider>();
        players = GameObject.FindGameObjectsWithTag("Player");
       
    }
    public void Update(){
        //if the script did not find players keep looking
        if(players.Length == 0 || players == null)
            players  = GameObject.FindGameObjectsWithTag("Player");
        //Figuring out which player is near the carriage
        foreach (GameObject player in players){
            PlayerPrompt = player.GetComponentInChildren<Text>();
            playerInfo = player.GetComponent<AtSpawn>();
            if(carriageCollider.bounds.Contains(player.transform.position)){
                if(playerInfo.hasGold && player.transform.Find("PlayerBody").gameObject.tag == "Guard"){
                    PlayerPrompt.text = "Press E to deposit gold.";
                    PlayerPrompt.enabled = true;
                    if (Input.GetButtonDown("Interact")){
                        this.goldAmmount++;
                        playerInfo.SethasGold(false);
                        PlayerPrompt.enabled = false;
                    }
                }
                else if(!playerInfo.hasGold && player.transform.Find("PlayerBody").gameObject.tag == "Bandit"){
                    PlayerPrompt.text = "Press E to steal gold.";
                    PlayerPrompt.enabled = true;
                    if (Input.GetButtonDown("Interact")){
                        this.goldAmmount--;
                        playerInfo.SethasGold(true);
                        PlayerPrompt.enabled = false;
                    }
                }
            }
        }
    }
}
