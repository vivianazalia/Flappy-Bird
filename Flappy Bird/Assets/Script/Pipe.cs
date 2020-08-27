﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] private Bird bird;
    [SerializeField] private float speed = 1;

    void Update()
    {
        if(!bird.IsDead())
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }
    }

    //burung mati saat menabrak pipa
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //detect object yang menabrak collider pipa adalah bird
        Bird bird = collision.gameObject.GetComponent<Bird>();

        if (bird)
        {
            Collider2D collider = GetComponent<Collider2D>();

            if (collider)
            {
                //menghilangkan collider pada pipa setelah ditabrak bird agar saat bird mati dapat jatuh ke tanah
                collider.enabled = false;
            }

            bird.Dead();
        }
    }
}
