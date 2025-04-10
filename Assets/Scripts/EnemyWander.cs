using UnityEngine;
using System.Collections;

public class EnemyWander : MonoBehaviour
{
    [SerializeField] public float speed = 3f;
    private Rigidbody2D rb;
    private Vector2 direction;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(ChangeDirectionRoutine());
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }

    private IEnumerator ChangeDirectionRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.7f);
            ChooseRandomDirection();
        }
    }


    private void ChooseRandomDirection()
    {
        int dir = Random.Range(0, 4);
        switch (dir)
        {
            case 0: direction = Vector2.up; break;
            case 1: direction = Vector2.down; break;
            case 2: direction = Vector2.left; break;
            case 3: direction = Vector2.right; break;
        }
    }
}
