using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public GameManager GameManager;
    public int health;
    public int damage;
    public Transform player;
    public GameObject particlesystem;

    public bool isFlipped = false;

    public Slider healthBar;
    public Image fill;

    public Gradient sliderGradient;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = FindObjectOfType<GameManager>();

        fill.color = sliderGradient.Evaluate(1f);
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = health;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            health -= damage;
            fill.color = sliderGradient.Evaluate(healthBar.normalizedValue);
            Destroy(other.gameObject);
        }
        if (healthBar.value == 0)
        {
            healthBar.gameObject.SetActive(false);
            particlesystem.gameObject.SetActive(false);
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Player"))
        {
            //Player Respawned sofort an Checkpoint 
            GameManager.RespawnPlayer();

        }
    }

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }
}
