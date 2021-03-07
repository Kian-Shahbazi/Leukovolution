using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets._2D
{
    public class Restarter : MonoBehaviour
    {
        public GameManager GameManager;

        private void Start()
        {
            GameManager = FindObjectOfType<GameManager>();
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                GameManager.RespawnPlayer();
            }
        }
    }
}
