using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateGuardsGold : MonoBehaviour{
    [SerializeField] private GameObject carriage;
    [SerializeField] private ProgressBar guardGoldProgressBar;
    private float banditGold, carriageGold;
    void UpdateProgressBar(){
        banditGold = gameObject.transform.parent.Find("BanditGoldProgressBar").gameObject.GetComponent<UpdateBanditsGold>().GetnumGold();
        carriageGold = carriage.GetComponent<CarriageGold>().GetGoldAmnt();
        Debug.Log(carriageGold/(carriageGold+banditGold));
        guardGoldProgressBar.UpdateValue(carriageGold/(carriageGold+banditGold));
    }
    // Start is called before the first frame update
    void Start(){
        carriage = GameObject.FindWithTag("Carriage");
        guardGoldProgressBar = gameObject.GetComponent<ProgressBar>();
        UpdateProgressBar();    
    }
    // Update is called once per frame
    void Update(){
        UpdateProgressBar();
    }
}
