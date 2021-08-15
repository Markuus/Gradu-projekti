using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinSystem : MonoBehaviour
{

    public TextMeshProUGUI coinCounterText;
    public static int coinsTotal;

    private void Awake()
    {
        coinsTotal = 0;
    }
    // Update is called once per frame
    void Update()
    {
        coinCounterText.text = coinsTotal.ToString(); 
    }

    public int getCoinsTotal()
    {
        return coinsTotal;
    }

    public void SetCoinsTotal(int coins)
    {
        coinsTotal = coins;
    }
}
