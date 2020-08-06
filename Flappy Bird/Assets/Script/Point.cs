﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    [SerializeField] private Bird bird;
    [SerializeField] private float speed = 1;

    void Update()
    {
        if (!bird.IsDead())
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }
    }

    //mengatur ukuran point
    public void SetSize(float size)
    {
        BoxCollider2D collider = GetComponent<BoxCollider2D>();

        if(collider != null)
        {
            collider.size = new Vector2(collider.size.x, size);
        }
    }

    //saat bird menabrak point
    private void OnTriggerExit2D(Collider2D collision)
    {
        Bird bird = collision.gameObject.GetComponent<Bird>();

        if(bird && !bird.IsDead())
        {
            bird.AddScore(1);
        }
    }
}
