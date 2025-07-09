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
            rb.gravityScale = 0f; // �߷� ���� ����!
            rb.velocity = direction * speed;
        }
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") //�÷��̾� �±� �ʿ���. �ɾ���
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
