using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class countdown : MonoBehaviour
{
    private float timer;
    public float roundTimer;
    public Text Timer;
    public GameManager GameManager;
    // Start is called before the first frame update
    void Start()
    {
        timer = roundTimer;
        GameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        roundTimer = roundTimer - Time.deltaTime;
        Timer.text = roundTimer.ToString("0");

        if (roundTimer <= 0f)
        {
            Debug.Log("Ende");
            GameManager.RespawnPlayer();
            roundTimer = timer;


        }
    }

    
}
