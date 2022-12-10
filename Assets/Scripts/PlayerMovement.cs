using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // 2d movement
        // decelerate faster than accelerating

        // get input
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if (x == 0 && y == 0)
        {
            return;
        }

        // get cam bounds
        float camWidth = cam.orthographicSize * cam.aspect;
        float camHeight = cam.orthographicSize;

        // move player but don't go off screen
        float xleftBound = -camWidth + transform.localScale.x;
        float xrightBound = camWidth - transform.localScale.x;
        float ybottomBound = -camHeight + transform.localScale.y;
        float ytopBound = camHeight - transform.localScale.y;
        float toBeX = transform.position.x + x * speed * Time.deltaTime;
        float toBeY = transform.position.y + y * speed * Time.deltaTime;
        if (toBeX > xleftBound && toBeX < xrightBound)
        {
            transform.position += new Vector3(x * speed * Time.deltaTime, 0, 0);
        }

        if (toBeY > ybottomBound && toBeY < ytopBound)
        {
            transform.position += new Vector3(0, y * speed * Time.deltaTime, 0);
        }

    }
}
