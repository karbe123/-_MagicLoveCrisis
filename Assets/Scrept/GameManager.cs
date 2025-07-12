using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private float time;
    private bool isgameover;
    public Text timetext;



    //�� �Ѿ�� ���� �ʿ�
    private bool sceneLoaded = false;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isgameover)
        {
            time += Time.deltaTime;
            timetext.text = "Time:" + time.ToString("F2");
        }
        else if (!sceneLoaded)
        {
            sceneLoaded = true;

            //�ְ��� �����ϰ� �������� �Ѱܾ���
            float oldBest = PlayerPrefs.GetFloat("BestTime", 0f);
            if (time > oldBest)
            {
                PlayerPrefs.SetFloat("BestTime", time);
            }

            PlayerPrefs.SetFloat("LastTime", time); //�ð� ����

            SceneManager.LoadScene("Gameover"); //�������Ѿ��̸�����

        }
    }

    public void EndGame()
    {
        isgameover = true;
    }
}
