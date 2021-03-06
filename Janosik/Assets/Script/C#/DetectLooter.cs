using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Com.ZiomakiStudios.Janosik{
    public class DetectLooter : MonoBehaviour{
        #region Private Fields
        [SerializeField] private PlayerInfo playerAtSpawn;
        private Text playerPromptText;
        [SerializeField] private MaintainLootChest chestController;
        [SerializeField] private SphereCollider chestCollider;
        [SerializeField] private List<GameObject> players;
        #endregion
        void Start(){
            chestController = gameObject.transform.parent.gameObject.GetComponent<MaintainLootChest>(); 
            chestCollider = gameObject.GetComponent<SphereCollider>();
            players  = ObjectPool.SharedInstance.GetActiveObjects(2);
        }
        void Update(){
            players  = ObjectPool.SharedInstance.GetActiveObjects(2);
            foreach(GameObject player in players){
                if(chestCollider.bounds.Contains(player.transform.position) && !playerAtSpawn.hasGold){
                    playerPromptText = player.GetComponentInChildren<Text>();
                    playerPromptText.enabled = true;
                    if(Input.GetButtonDown("Interact")){
                        Debug.Log("We are stealing Gold!");
                        chestController.stealGold();
                        player.GetComponent<PlayerInfo>().hasGold = true;
                        playerPromptText.enabled = false;
                    }
                } 
            }
        }
    }
}
