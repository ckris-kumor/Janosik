using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Com.ZiomakiStudios.Janosik{
    public class GameResults : MonoBehaviour{
    
        public Text GameResult;
        public Text KillCountText;
        // Start is called before the first frame update
        public void Awake(){
            KillCountText.text = "Kills: " + GameStats.killCount;
        }
        // Update is called once per frame
        public void Start(){
            Cursor.visible = true;
            if (GameStats.BanditsGold < GameStats.GuardsGold)
                GameResult.text = "Victory!";
            else if (GameStats.BanditsGold > GameStats.GuardsGold)
                GameResult.text = "Defeat";
            else if (GameStats.BanditsGold == GameStats.GuardsGold)
                GameResult.text = "Tie";
        }
        public void Update(){
            Cursor.visible = true;
        }
    }
}
