using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateGuardsGold : MonoBehaviour
{
    public GameObject carriage;
    public Text GuardsGoldText;

    // Start is called before the first frame update
    void Start()
    {
        GuardsGoldText.text = "Guard: " + carriage.GetComponent<CarriageGold>().goldAmmount;
    }

    // Update is called once per frame
    void Update()
    {
        GuardsGoldText.text = "Guard: " + carriage.GetComponent<CarriageGold>().goldAmmount;
    }
}
