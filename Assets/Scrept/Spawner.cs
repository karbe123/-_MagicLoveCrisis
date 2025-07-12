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

    //y축 이동을 위한 변수 선언
    public float moveSpeed = 2f;          // 이동 속도
    public float minY = -2f;              // 최소 Y 위치
    public float maxY = 2f;               // 최대 Y 위치
    private float targetY;                // 다음에 이동할 Y 위치

    //효과음을 위해 변수선언
    public Transform firePoint;
    public AudioClip fireSound;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        interval = Random.Range(intervalMin, intervalMax);
        timeAfterSpawm = 0f;

        //타켓지정 컴포넌트로 찾기
        target = FindObjectOfType<Player>().transform;

        //y축 처음 설ㅇ정
        targetY = Random.Range(minY, maxY);

        //효과음위함 오디오소스 받아오기
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        //y축 랜덤이동
        float step = moveSpeed * Time.deltaTime;
        Vector3 newPos = transform.position;
        newPos.y = Mathf.MoveTowards(transform.position.y, targetY, step);
        transform.position = newPos;
        if (Mathf.Approximately(transform.position.y, targetY))
        {
            targetY = Random.Range(minY, maxY);
        }

        //총알스폰
        timeAfterSpawm += Time.deltaTime;
        if (timeAfterSpawm >= interval)
        {
            GameObject fire = Instantiate(firePrefab, transform.position, Quaternion.identity);

            Vector2 direction = (target.position - transform.position).normalized; //방향설정
            fire.GetComponent<fire>().SetDirection(direction); // 총알에게 방향 전달ㄹ

            interval = Random.Range(intervalMin, intervalMax);
            timeAfterSpawm = 0f;

            // 소리 재생
            audioSource.PlayOneShot(fireSound);
        }

    }
  

}
