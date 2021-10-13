using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GoldBarUIController : MonoBehaviour
{
    [SerializeField] private Image GoldImage;
    [SerializeField] private AtSpawn playerInfo;

    // Start is called before the first frame update
    void Start(){
        playerInfo = GetComponentInParent<AtSpawn>();
        GoldImage = GetComponent<Image>();
        GoldImage.enabled = false;
    }

    // Update is called once per frame
    void Update(){
        GoldImage.enabled = playerInfo.GethasGold();
    }
}
