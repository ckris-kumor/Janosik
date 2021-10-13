using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateAmmo : MonoBehaviour{
    GameObject player;
    GameObject AmmoTextField;
    // Start is called before the first frame update
    public void Start(){
        player = GameObject.FindGameObjectWithTag("Guard");
        AmmoTextField = GameObject.FindGameObjectWithTag("AmmoTextField");
        AmmoTextField.GetComponent<Text>().text = player.GetComponent<AtSpawn>().GetCurrAmmo().ToString() + "/" + player.GetComponent<AtSpawn>().GetMaxAmmo().ToString();
    }

    // Update is called once per frame
    public void Update(){
        AmmoTextField.GetComponent<Text>().text = player.GetComponent<AtSpawn>().GetCurrAmmo().ToString() + "/" + player.GetComponent<AtSpawn>().GetMaxAmmo().ToString();
    }
}
