using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoverboard : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 newPos;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;

        speed = (5f);
    }

    // Update is called once per frame
    void Update()
    {
        newPos = startPos;
        newPos.x = newPos.x + Mathf.PingPong(Time.time * speed, 150) - 100;

        transform.position = newPos;
    }
}
