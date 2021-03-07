using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovingY : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 newPos;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;

        speed = Random.Range(5f, 7f);
    }

    // Update is called once per frame
    void Update()
    {
        newPos = startPos;
        newPos.y = newPos.y + Mathf.PingPong(Time.time * speed, 6) - 3;

        transform.position = newPos;
    }
}
