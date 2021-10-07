using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpdateBanditsGold : MonoBehaviour{
    private float numGold;
    [SerializeField] private ProgressBar banditGoldProgressBar;
    [SerializeField] private GameObject carriage;
    void UpdateProgressBar(){
        banditGoldProgressBar.UpdateValue(numGold/(carriage.GetComponent<CarriageGold>().GetGoldAmnt()+numGold));
    }
    // Start is called before the first frame update
    void Start(){
        carriage = GameObject.FindWithTag("Carriage");
        banditGoldProgressBar = gameObject.GetComponent<ProgressBar>();
        numGold = 0;
        Debug.Log("Bandit Gold ");
        UpdateProgressBar();

    }
    public float GetnumGold(){
        return numGold;
    }
    public void DepositGold(){
        numGold += 1;
        UpdateProgressBar();
        
    }
    public void WithdrawGold(){
        numGold -= 1;
        UpdateProgressBar();
    }

}
