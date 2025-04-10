using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    AudioSource audioSource;
    [SerializeField] AudioClip coinSound;
    [SerializeField] AudioClip enemySound;
    public float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Coletavel")
        {
            audioSource.PlayOneShot(coinSound);
            GameController.Collect();
            Destroy(other.gameObject);
        }
        if (other.tag == "Inimigo")
        {
            audioSource.PlayOneShot(enemySound);
            GameController.PlayerDied();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Inimigo")
        {
            audioSource.PlayOneShot(enemySound);
            GameController.PlayerDied();
        }
    }
}
