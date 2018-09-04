using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class APBullet : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;

    private Collider2D myCollider;
    private Rigidbody2D myRigidbody;

    //More slow than the normal bullet
    [SerializeField]
    private float force = 5F;

    //Time auto destroy time of the bullet
    [SerializeField]
    private float autoDestroyTime = 5F;
    // Use this for initialization
    void Start () {
        myCollider = GetComponent<Collider2D>();
        myRigidbody = GetComponent<Rigidbody2D>();

        myRigidbody.AddForce(transform.up * force, ForceMode2D.Impulse);

        Invoke("AutoDestroy", autoDestroyTime);
    }

    private void AutoDestroy()
    {
        Destroy(gameObject);
        Destroy(gameObject);
    }

    //En
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hazard impact");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update () {
		
	}
}
