using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class APBullet : Bullet
{
    protected override void Start ()
    {
        base.Start();
    }

    protected override void AutoDestroy()
    {
        base.AutoDestroy();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hazard impact");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
