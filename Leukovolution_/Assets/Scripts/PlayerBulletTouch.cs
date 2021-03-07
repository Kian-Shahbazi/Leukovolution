using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using JetBrains.Annotations;

public class PlayerBulletTouch : MonoBehaviour
{
    public Transform firepoint;
    public Transform player;
    public Rigidbody2D bulletPrefab;
    Rigidbody2D clone;
    public float bulletSpeed = 300f;
    // Start is called before the first frame update
    void Start()
    {
        firepoint = GameObject.Find("Firepoint").transform;
    }
    public void fire()
    {
        Debug.Log("Fire");
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Debug.Log("Feuer Frei");
            //Attack();
        }
    }
    public void Attack()
    {
        if (firepoint.position.x > player.position.x)
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
