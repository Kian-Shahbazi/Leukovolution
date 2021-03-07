using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelBoss : MonoBehaviour
{
    private bool bossdeath = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (!FindObjectOfType<Boss>())
                bossdeath = true;
            if (bossdeath)
            {
                FindObjectOfType<GameManager>().Hearthlifesaver();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
