using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateHealth : MonoBehaviour
{
    GameObject player;
    GameObject HPTextField;
 
    // Start is called before the first frame update
    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Bandit");
        HPTextField = GameObject.Find("HPTextField");
        
    }

    
    void Update()
    {
        HPTextField.GetComponent<Text>().text = "Bandit HP: " + player.GetComponent<AtSpawn>().Gethp().ToString();
        
    }
}
