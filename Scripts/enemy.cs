using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        bird bird = collision.collider.GetComponent<bird>();

        if (bird != null)
        {
            Destroy(gameObject);
            return;
        }

        enemy enemy = collision.collider.GetComponent<enemy>();

        if (enemy != null)

        {
            return;
        }

        if (collision.contacts[0].normal.y < -0.5)
        {
            Destroy(gameObject);
        }

    }
}
