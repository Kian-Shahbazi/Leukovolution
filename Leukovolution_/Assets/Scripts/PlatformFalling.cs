using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFalling : MonoBehaviour
{
    private Rigidbody2D rb2d_Platform;

    public float delay;

    private GameObject platform;
    // Start is called before the first frame update
    void Start()
    {
        rb2d_Platform = GetComponent<Rigidbody2D>();
        platform = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            Debug.Log("Spieler erkannt");
            StartCoroutine(Fall());
        }
    }

    IEnumerator Fall()
    {
        yield return new WaitForSeconds(delay);
        rb2d_Platform.isKinematic = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Killzone")
        {
            Destroy(platform);
        }
    }

}
