using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject firePrefab;
    public float intervalMin = 0.5f;
    public float intervalMax = 3f;

    private Transform target;
    private float interval;
    private float timeAfterSpawm;

    //y�� �̵��� ���� ���� ����
    public float moveSpeed = 2f;          // �̵� �ӵ�
    public float minY = -2f;              // �ּ� Y ��ġ
    public float maxY = 2f;               // �ִ� Y ��ġ
    private float targetY;                // ������ �̵��� Y ��ġ

    //ȿ������ ���� ��������
    public Transform firePoint;
    public AudioClip fireSound;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        interval = Random.Range(intervalMin, intervalMax);
        timeAfterSpawm = 0f;

        //Ÿ������ ������Ʈ�� ã��
        target = FindObjectOfType<Player>().transform;

        //y�� ó�� ������
        targetY = Random.Range(minY, maxY);

        //ȿ�������� ������ҽ� �޾ƿ���
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        //y�� �����̵�
        float step = moveSpeed * Time.deltaTime;
        Vector3 newPos = transform.position;
        newPos.y = Mathf.MoveTowards(transform.position.y, targetY, step);
        transform.position = newPos;
        if (Mathf.Approximately(transform.position.y, targetY))
        {
            targetY = Random.Range(minY, maxY);
        }

        //�Ѿ˽���
        timeAfterSpawm += Time.deltaTime;
        if (timeAfterSpawm >= interval)
        {
            GameObject fire = Instantiate(firePrefab, transform.position, Quaternion.identity);

            Vector2 direction = (target.position - transform.position).normalized; //���⼳��
            fire.GetComponent<fire>().SetDirection(direction); // �Ѿ˿��� ���� ���ޤ�

            interval = Random.Range(intervalMin, intervalMax);
            timeAfterSpawm = 0f;

            // �Ҹ� ���
            audioSource.PlayOneShot(fireSound);
        }

    }
  

}
