using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter2D (Collider2D collision)
    {
        Pipe pipe = collision.gameObject.GetComponent<Pipe>();
        Ground ground = collision.gameObject.GetComponent<Ground>();

        if (pipe)
        {
            Destroy(collision.gameObject);
        }

        if (ground)
        {
            Destroy(gameObject);
        }
    }
}
