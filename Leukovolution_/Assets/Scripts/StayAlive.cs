using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayAlive : MonoBehaviour
{
    int coinCounter;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        coinCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setCoinCounter(int coins)
    {
        coinCounter = coins;
    }

    public int getCoinCounter()
    {
        return coinCounter;
    }
}
