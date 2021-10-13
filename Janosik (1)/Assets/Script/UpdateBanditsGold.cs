using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpdateBanditsGold : MonoBehaviour{
    private float numGold;
    [SerializeField] private ProgressBar banditGoldProgressBar;
    [SerializeField] private CarriageGold carriageGoldInfo;
    [SerializeField] private DepositLoot banditBaseGoldInfo;
    void UpdateProgressBar(){

        banditGoldProgressBar.UpdateValue(banditBaseGoldInfo.GetNumGold()/(carriageGoldInfo.GetGoldAmnt()+banditBaseGoldInfo.GetNumGold()));
    }
    // Start is called before the first frame update
    void Start(){
        carriageGoldInfo = GameObject.FindWithTag("Carriage").transform.Find("wagon1").gameObject.GetComponent<CarriageGold>();
        banditBaseGoldInfo = GameObject.FindWithTag("BanditBase").transform.Find("Bandit's Stash").GetComponent<DepositLoot>();
        banditGoldProgressBar = gameObject.GetComponent<ProgressBar>();
        UpdateProgressBar();
    }
    void Update(){
        UpdateProgressBar();
    }
}
