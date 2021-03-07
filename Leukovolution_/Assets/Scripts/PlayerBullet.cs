using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public Transform firepoint;
    public Transform player;
    public Rigidbody2D bulletPrefab;
    Rigidbody2D clone;
    public float bulletSpeed = 100000f;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        firepoint = GameObject.Find("Firepoint").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Feuer Frei");
            Attack();
        }
    }
    void Attack()
    {
        if(firepoint.position.x > player.position.x)
        {
            clone = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
            clone.AddForce(firepoint.transform.right * bulletSpeed);
        }
        else
        {
            clone = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
            clone.AddForce(firepoint.transform.right * -bulletSpeed);
        }
    }
}
