using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyYposition : MonoBehaviour
{
    public GameManager GameManager;

    public Vector3 startPos;
    public Vector3 newPos;
    public Vector3 tempPos;
    public float speed;
    public SpriteRenderer sr;

    void Start()
    {
        GameManager = FindObjectOfType<GameManager>();

        startPos = transform.position;
        //zufällige Geschwindigkeit generieren
        speed = Random.Range(5f, 8f);
        tempPos = startPos;

        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        newPos = startPos;
        newPos.y = newPos.y + Mathf.PingPong(Time.time * speed, 6) - 3;

        transform.position = newPos;
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Player Respawned sofort an Checkpoint 
            GameManager.RespawnPlayer();
        }

        if (other.gameObject.tag == "Bullet")
        {
            Destroy(other.gameObject, 0f);
            Destroy(gameObject, 0.2f);
        }

    }
}
