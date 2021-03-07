using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checkpoint : MonoBehaviour
{
    public GameManager GameManager;
    [SerializeField] private GameObject saveInfo; 
    // Start is called before the first frame update
    void Start()
    {
        GameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameManager.currentCheckpoint = gameObject;
            StartCoroutine(showText(2f));
        }
    }

    IEnumerator showText(float time)
    {
        Debug.Log("Wird abgespielt");
        saveInfo.SetActive(true);
        yield return new WaitForSeconds(time);
        saveInfo.SetActive(false);
    }
}
