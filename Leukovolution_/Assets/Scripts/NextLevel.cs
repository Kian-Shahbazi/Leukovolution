using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    Player player = null;
    public bool isendingoflevel = true;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (!player)
                player = other.gameObject.GetComponent<Player>();
            if (player.coinCounter >= 6 || !isendingoflevel)
            {
                FindObjectOfType<GameManager>().Hearthlifesaver();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}