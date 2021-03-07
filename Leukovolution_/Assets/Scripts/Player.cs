using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //private int coinCounter;
    public Text scoreText;
    public Text LebenText;
    private GameManager gameManager;
    //StayAlive stayAlive;
    public int coinCounter;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        //stayAlive = GameObject.Find("StayAlive").GetComponent<StayAlive>();
        //coinCounter = stayAlive.getCoinCounter();
        scoreText.text = coinCounter.ToString();
        //1.DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Impfstoff")
        {
            
            //Grafik Deaktivieren
            other.gameObject.GetComponent<Renderer>().enabled = false;
            //Collider Deaktivieren
            other.gameObject.GetComponent<Collider2D>().enabled = false;
            //münzensound abspielen
            AudioSource audio = other.gameObject.GetComponent<AudioSource>();
            audio.Play();
            //Münze Zerstören
            Destroy (other.gameObject, audio.clip.length);
            coinCounter = coinCounter += 1;
            //stayAlive.setCoinCounter(coinCounter);
            scoreText.text = coinCounter.ToString();
            Debug.Log("Impfstoffe:" +coinCounter);
        }
        if (other.tag == "herz")
        {
            other.gameObject.GetComponent<Renderer>().enabled = false;
            other.gameObject.GetComponent<Collider2D>().enabled = false;
            AudioSource audio = other.gameObject.GetComponent<AudioSource>();
            audio.Play();
            Destroy(other.gameObject, audio.clip.length);
            gameManager.Atlifes(1);
            
        }
        if (other.tag == "Checkpoint")
        {
            other.gameObject.GetComponent<Renderer>().enabled = false;
            other.gameObject.GetComponent<Collider2D>().enabled = false;
            AudioSource audio = other.gameObject.GetComponent<AudioSource>();
            audio.Play();
            Debug.Log("Checkpoint erreicht");
        }
        if (other.tag == "Erreger")
        {
            other.gameObject.GetComponent<Renderer>().enabled = false;
            other.gameObject.GetComponent<Collider2D>().enabled = false;
            AudioSource audio = other.gameObject.GetComponent<AudioSource>();
            audio.Play();
            Destroy(other.gameObject, audio.clip.length);
            Debug.Log("Erreger erreicht");
        }
    }
        
}
