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

    // Start is called before the first frame update
    void Start()
    {
        interval = Random.Range(intervalMin, intervalMax);
        timeAfterSpawm = 0f;

        //타켓지정 컴포넌트로 찾기
        target = FindObjectOfType<Player>().transform;

    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawm += Time.deltaTime;
        if (timeAfterSpawm >= interval)
        {
            GameObject fire = Instantiate(firePrefab, transform.position, transform.rotation);
            Vector2 direction = (target.position - transform.position).normalized; //방향설정
            fire.GetComponent<fire>().SetDirection(direction); // 총알에게 방향 전달ㄹ

            interval = Random.Range(intervalMin, intervalMax);
            timeAfterSpawm = 0f;
        }
    }
}
