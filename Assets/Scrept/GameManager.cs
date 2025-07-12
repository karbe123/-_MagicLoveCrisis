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



    //씬 넘어가기 전에 필요
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

            //최고기록 저장하고 다음씬에 넘겨야함
            float oldBest = PlayerPrefs.GetFloat("BestTime", 0f);
            if (time > oldBest)
            {
                PlayerPrefs.SetFloat("BestTime", time);
            }

            PlayerPrefs.SetFloat("LastTime", time); //시간 저장

            SceneManager.LoadScene("Gameover"); //내가정한씬이름으로

        }
    }

    public void EndGame()
    {
        isgameover = true;
    }
}
