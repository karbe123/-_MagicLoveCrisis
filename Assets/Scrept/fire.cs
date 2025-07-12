using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    private Vector2 direction;
    public float speed = 8f;

    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)//지피티가하랫음...
        {
            rb.gravityScale = 0f; //중력 0
            rb.velocity = direction * speed;

        }
        else
        {
            Debug.LogWarning(" Rigidbody2D 없음!");
        }
    }

    void Start()
    {
        Destroy(gameObject, 3f); // 이제 velocity 설정은 하지 말 것
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().Die();
            FindObjectOfType<GameManager>().EndGame(); //죽음선언해에 게임 메니저에서 다음씬 ㄱㄴ
            Destroy(gameObject);
        }
    }
}

    // Update is called once per frame

