using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Hazard : MonoBehaviour
{
    private Collider2D myCollider;
    private object myRigidbody;

    [SerializeField]
    private float resistance = 1F;

    // Use this for initialization
    protected void Start()
    {
        myCollider = GetComponent<Collider2D>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Bullet>() != null)
        {
            //TODO: Make this to reduce damage using Bullet.damage attribute
            resistance -= 1;

            if (resistance == 0)
            {
                //Desactiva
                //dejar de mover
                if (collision.gameObject.tag == "Invader")
                {
                    collision.gameObject.GetComponent<Invader>().move = false;
                }

                else
                {
                    collision.gameObject.SetActive(false);

                    UIManager.Instance.IncreaseHazardCount();
                }
            }
        }
    }
}