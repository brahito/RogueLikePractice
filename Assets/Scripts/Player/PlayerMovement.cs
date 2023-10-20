using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))] //Hace que el objeto que tenga el sprite este obligado a tenerlo
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Flip(float X)
    {
        if(X > 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }

    public void Mover(Vector2 movement)
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

}
