using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    private Vector2 direction;
    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
    }

    public float speed = 8f;
    private Rigidbody2D fireRigidbody2D;
    

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.gravityScale = 0f; // 중력 영향 제거!
            rb.velocity = direction * speed;
        }
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") //플레이어 태그 필요함. 걸어줘
        {

            other.GetComponent<Player>().Die();
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
