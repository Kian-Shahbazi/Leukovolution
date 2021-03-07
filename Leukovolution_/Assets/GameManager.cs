using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets._2D;

public class GameManager : MonoBehaviour
{
    public GameObject currentCheckpoint;
    public GameObject player;
    private int leben = 7;
    private float timer;
    public Text lebenText;

    public Text Timer;
    public float roundTimer;
    

    private void Start()
    {
        timer = roundTimer;
        lebenText.text = leben.ToString();
        if (PlayerPrefs.HasKey("Hearthsave"))
        {
            leben = PlayerPrefs.GetInt("Hearthsave");
            lebenText.text = leben.ToString();
        }
    
    //2.DontDestroyOnLoad(gameObject);
}
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Spiel wird beendet.");
            Application.Quit();
        }

        if (SceneManager.GetActiveScene().buildIndex == 12)
        {
            roundTimer -= Time.deltaTime;
            Timer.text = roundTimer.ToString("0");

            if (roundTimer <= 0f)
            {
                Debug.Log("Ende");
                RespawnPlayer();
                roundTimer = timer;


            }
        }
    }

    public void RespawnPlayer()
    {
        //Leben abziehen
        Removelifes(1);
        //Überprüfen ob spieler noch Leben hat
        if (leben > 0)
        {
            //falls ja = Respawn
            player.transform.position = currentCheckpoint.transform.position;
        }
        
        
    }
    public void Atlifes(int difference)
    {
        leben += difference;
        lebenText.text = leben.ToString();

    }
    public void Removelifes(int difference)
    {
        leben -= difference;
        lebenText.text = leben.ToString();
        if (leben <= 0)
        {
            //falls nein == Spielende
            SceneManager.LoadScene(0);
        }
    }
    public void Hearthlifesaver()
    {
        PlayerPrefs.SetInt("Hearthsave", leben);
    }
}
