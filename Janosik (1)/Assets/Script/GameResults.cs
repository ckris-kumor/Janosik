using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameResults : MonoBehaviour
{
   
    public Text GameResult;
    int BanditsGold, GuardsGold;
    public Text KillCountText;
    // Start is called before the first frame update
    public void Awake()
    {
        BanditsGold = GameStats.BanditGold;
        GuardsGold = GameStats.GuardGold;
        KillCountText.text = "Kills: " + GameStats.killCount;
    }
    // Update is called once per frame
    public void Start()
    {
        Cursor.visible = true;
        Debug.Log("Bandits had " + BanditsGold);
        Debug.Log("Guards had " + GuardsGold);
        if (BanditsGold < GuardsGold)
            GameResult.text = "Victory!";
        else if (BanditsGold > GuardsGold)
            GameResult.text = "Defeat";
        else if (BanditsGold == GuardsGold)
            GameResult.text = "Tie";


    }
    public void Update()
    {
        Cursor.visible = true;
    }
}
