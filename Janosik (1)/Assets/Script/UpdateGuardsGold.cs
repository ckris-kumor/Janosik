using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateGuardsGold : MonoBehaviour{
    [SerializeField] private ProgressBar guardGoldProgressBar;
    [SerializeField] private CarriageGold carriageGoldInfo;
    private float banditGold, carriageGold;
    [SerializeField] private DepositLoot banditGoldInfo;
    void UpdateProgressBar(){
        banditGold = banditGoldInfo.GetNumGold();
        carriageGold = carriageGoldInfo.GetGoldAmnt();
        GameStats.GuardsGold = (int)carriageGold;
        guardGoldProgressBar.UpdateValue(carriageGold/(carriageGold+banditGold));
    }
    // Start is called before the first frame update
    void Start(){
        carriageGoldInfo = GameObject.FindWithTag("Carriage").GetComponent<CarriageGold>();
        guardGoldProgressBar = gameObject.GetComponent<ProgressBar>();
        banditGoldInfo = GameObject.FindWithTag("BanditBase").transform.Find("Bandit's Stash").gameObject.GetComponent<DepositLoot>();
        UpdateProgressBar();    
    }
    // Update is called once per frame
    void Update(){
        UpdateProgressBar();
    }
}
