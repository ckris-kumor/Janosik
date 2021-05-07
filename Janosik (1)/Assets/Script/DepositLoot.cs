using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DepositLoot : MonoBehaviour
{
    
    public SphereCollider LootDetectionVolume;
    GameObject[] players = new GameObject[2];
    public Text PlayerPrompt;
    Text BanditGoldText;
    public void Awake()
    {
        players[0] = GameObject.FindGameObjectWithTag("Guard");
        players[1] = GameObject.FindGameObjectWithTag("Bandit");
    }
    public void Start()
    {

        PlayerPrompt.gameObject.SetActive(true);
        BanditGoldText = GameObject.FindGameObjectWithTag("BanditGoldTextField").GetComponent<Text>();
        
    }

    // Update is called once per frame
    public void Update()
    {
        foreach (GameObject player in players)
        {
            
            if (LootDetectionVolume.bounds.Contains(player.transform.position))
            {
                bool hasGold = player.GetComponent<AtSpawn>().GethasGold();
                if (player.CompareTag("Bandit") && hasGold)
                {
                    PlayerPrompt.text = "Press E to stash gold.";
                    PlayerPrompt.enabled = true;

                    BanditGoldText.GetComponent<UpdateBanditsGold>().DepositGold();
                    GameStats.BanditGold = (BanditGoldText.GetComponent<UpdateBanditsGold>().GetnumGold());
                    player.GetComponent<AtSpawn>().SethasGold(false);
                    PlayerPrompt.enabled = false;


                }
                else if ((player.CompareTag("Guard") || player.CompareTag("Player")) && !(hasGold) &&(BanditGoldText.GetComponent<UpdateBanditsGold>().GetnumGold() != 0))
                {

                    PlayerPrompt.text = "Press E to steal Bandit's gold.";
                    PlayerPrompt.enabled = true;
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        BanditGoldText.GetComponent<UpdateBanditsGold>().WithdrawGold();
                        GameStats.BanditGold = (BanditGoldText.GetComponent<UpdateBanditsGold>().GetnumGold());
                        player.GetComponent<AtSpawn>().SethasGold(true);
                        PlayerPrompt.enabled = false;
                    }

                }
                

            }
            
        }
    }
}
