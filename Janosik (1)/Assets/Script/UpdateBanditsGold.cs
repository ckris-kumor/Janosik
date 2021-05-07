using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpdateBanditsGold : MonoBehaviour
{
    int numGold;
    public Text BanditGoldText;
    // Start is called before the first frame update
    void Start()
    {
        numGold = 0;
        BanditGoldText.text = BanditGoldText.text = "Bandits: " + numGold;
    }



    public int GetnumGold()
    {
        
        return numGold;
    }

    public void DepositGold()
    {
        numGold += 1;
        BanditGoldText.text = "Bandits: " + numGold;
        
    }

    public void WithdrawGold()
    {
        numGold -= 1;
        BanditGoldText.text = "Bandits: " + numGold;
    }

}
