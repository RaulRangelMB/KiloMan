using System.Collections;
using UnityEngine;

public class EnemyMovemen : MonoBehaviour
{
    [SerializeField] public float speed = 3f;
    [SerializeField] public GameObject player;
    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(AdjustSpeed());
    }

    void FixedUpdate()
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }

    private IEnumerator AdjustSpeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            speed += 0.05f;
        }
    }
}
