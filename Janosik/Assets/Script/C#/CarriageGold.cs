using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CarriageGold : MonoBehaviour
{
    [Tooltip("This collider will detect if the player is a the immediate area of the carriage.")]
    [SerializeField] private SphereCollider carriageCollider;
    [SerializeField] private List<GameObject> players;
    [SerializeField] private int goldAmmount;
    [SerializeField] private Text PlayerPrompt;
    [SerializeField] private AtSpawn playerInfo;
    [SerializeField] private Transform interactPromptLoc;
    [SerializeField] private Camera playerCam;
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
        carriageCollider = GetComponent<SphereCollider>();
        players = ObjectPool.SharedInstance.GetActiveObjects(2);
        interactPromptLoc = transform.Find("PromptInteractLoc");
    }
    public void Update(){
        players = ObjectPool.SharedInstance.GetActiveObjects(2);
        //Figuring out which player is near the carriage
        foreach (GameObject player in players){
            playerInfo = player.GetComponent<AtSpawn>();
            playerCam = player.GetComponentInChildren<Camera>();
            PlayerPrompt = player.transform.Find("Camera/Canvas/InteractPrompt").gameObject.GetComponent<Text>();;
            PlayerPrompt.transform.position = playerCam.WorldToScreenPoint(interactPromptLoc.position);
            if(carriageCollider.bounds.Contains(player.transform.position)){
                if(playerInfo.hasGold && player.transform.tag == "Guard"){
                    PlayerPrompt.enabled = true;
                    if (Input.GetButtonDown("Interact")){
                        this.goldAmmount++;
                        playerInfo.SethasGold(false);
                        PlayerPrompt.enabled = false;
                    }
                }
                else if(!playerInfo.hasGold && player.transform.tag == "Bandit"){
                    PlayerPrompt.enabled = true;
                    if (Input.GetButtonDown("Interact")){
                        this.goldAmmount--;
                        playerInfo.SethasGold(true);
                        PlayerPrompt.enabled = false;
                    }
                }
            }
            else
                PlayerPrompt.enabled = false;
        }
    }
}
