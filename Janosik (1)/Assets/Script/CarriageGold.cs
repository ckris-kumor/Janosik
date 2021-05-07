using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CarriageGold : MonoBehaviour
{
    public SphereCollider carriageCollider;
    public GameObject[] players;
    public int goldAmmount;
    public Text PlayerPrompt;

    public int GetGoldAmnt()
    {
        return goldAmmount;
    }

    public void SetGoldAmnt(int ammount)
    {
        this.goldAmmount = ammount;
    }

    public void StealGold()
    {
        this.goldAmmount -= 1;
    }

    public void DepositGold()
    {
        this.goldAmmount += 1;
    }    

    public void Start()
    {
        SetGoldAmnt(4);
       
    }

    public void Update()
    {
        foreach (GameObject player in players)
        {
            if (carriageCollider.bounds.Contains(player.transform.position) && !(player.GetComponent<AtSpawn>().GethasGold()) && player.CompareTag("Bandit"))
            {
                    this.goldAmmount--;
                    player.GetComponent<AtSpawn>().SethasGold(true);
                    GameObject.FindGameObjectWithTag("GuardsGoldText").GetComponent<UpdateGuardsGold>();
                    PlayerPrompt.enabled = false;
            }

            else if (carriageCollider.bounds.Contains(player.transform.position) && (player.GetComponent<AtSpawn>().GethasGold()) && player.CompareTag("Guard"))
            {
                PlayerPrompt.text = "Press E to deposit gold.";
                PlayerPrompt.enabled = true;


                if (Input.GetKeyDown(KeyCode.E))
                {
                    this.goldAmmount++;
                    
                    player.GetComponent<AtSpawn>().SethasGold(false);
                    PlayerPrompt.enabled = false;
                }

            }


            


        }

        GameStats.GuardGold = this.goldAmmount;
    }
}
