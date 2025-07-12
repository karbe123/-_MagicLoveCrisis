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
        if (rb != null)//����Ƽ���Ϸ���...
        {
            rb.gravityScale = 0f; //�߷� 0
            rb.velocity = direction * speed;

        }
        else
        {
            Debug.LogWarning(" Rigidbody2D ����!");
        }
    }

    void Start()
    {
        Destroy(gameObject, 3f); // ���� velocity ������ ���� �� ��
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().Die();
            FindObjectOfType<GameManager>().EndGame(); //���������ؿ� ���� �޴������� ������ ����
            Destroy(gameObject);
        }
    }
}

    // Update is called once per frame

