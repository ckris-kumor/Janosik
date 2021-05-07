using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectLooter : MonoBehaviour
{
    public SphereCollider chestCollider;
    
    private AtSpawn playerAtSpawn;

    private Text playerPromptText;
    public MaintainLootChest chestController;


    void OnCollisionEnter(Collision coll)
    {
        if (coll != null)
        {
            playerAtSpawn = coll.gameObject.GetComponent<AtSpawn>();
            playerPromptText = coll.gameObject.GetComponentInChildren<Text>();
            if(!playerAtSpawn.hasGold && chestController.getCurrGold() != 0)
            {
                playerPromptText.enabled = true;
                if(Input.GetKeyDown(KeyCode.E))
                {
                    chestController.stealGold();
                    playerAtSpawn.hasGold = true;
                }
            }
            else
                playerPromptText.enabled = false;
        }
    }
}
