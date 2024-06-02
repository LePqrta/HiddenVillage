using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Scripting;

public class MarketScript : MonoBehaviour
{

    public GameObject slot1Button;
    public TextMeshProUGUI text;
    public GameObject Market;

    public void Awake(){
        text.text="1";
        Market.SetActive(false);
    }

    public void MarketActivate(){
        Market.SetActive(true);
    }
    public void MarketDeactivate(){
        Market.SetActive(false);
    }

}
