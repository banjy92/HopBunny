﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour {

    public float jumpForce = 15f;
    Rigidbody2D rb;
    Animator bunnyanim;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb = collision.collider.GetComponent<Rigidbody2D>();
        bunnyanim = collision.collider.GetComponentInChildren<Animator>();
        float relativevel = collision.relativeVelocity.y;

        if (rb != null)
        {
            StartCoroutine(JumpAnim(relativevel));
        }
    }

    IEnumerator JumpAnim(float relativevel)
    {
        if(relativevel <= 0f)
        {
            bunnyanim.SetTrigger("touchDown");
        }
        yield return new WaitForSeconds(seconds: 0.225f);
        Vector2 velocity = rb.velocity;
        velocity.y = jumpForce;
        rb.velocity = velocity;
        gameObject.SetActive(false);
    }
}
