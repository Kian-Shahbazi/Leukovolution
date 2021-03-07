using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUP : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.Atlifes(1);
    }
}
