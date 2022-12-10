using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
    [SerializeField] private float _scrollSpeed = -5f;
    [SerializeField] private float _tileSizeY = 20f;
    private Vector2 _startPos;

    // Start is called before the first frame update
    void Start()
    {
        _startPos = transform.position - Vector3.up * (_tileSizeY / 2);
    }

    // Update is called once per frame
    void Update()
    {
        float newPos = Mathf.Repeat(Time.time * _scrollSpeed, _tileSizeY);
        transform.position = _startPos + Vector2.up * newPos;
    }
}
