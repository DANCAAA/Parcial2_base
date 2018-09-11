using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField]
    protected int damage = 1;

    protected Collider2D myCollider;
    protected Rigidbody2D myRigidbody;

    [SerializeField]
    protected float force = 10F;

    //Time auto destroy time of the bullet
    [SerializeField]
    protected float autoDestroyTime = 5F;

    // Use this for initialization
    protected virtual void Start()
    {
        myCollider = GetComponent<Collider2D>();
        myRigidbody = GetComponent<Rigidbody2D>();

        myRigidbody.AddForce(transform.up * force, ForceMode2D.Impulse);

        Invoke("AutoDestroy", autoDestroyTime);
    }

    protected virtual void AutoDestroy()
    {
        Destroy(gameObject);
    }
}