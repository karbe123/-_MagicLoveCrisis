using System.Collections; // 코루틴써서 시간 늦게 나타나게 하기
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public Text bestText;
    public Text lastTimeText;
    public float delay = 8f;

    void Start()
    {
        Time.timeScale = 1f;
        bestText.gameObject.SetActive(false);
        lastTimeText.gameObject.SetActive(false);
        StartCoroutine(ShowTextsAfterDelay());
    }

    IEnumerator ShowTextsAfterDelay()
    {
        yield return new WaitForSecondsRealtime(delay);

        float best = PlayerPrefs.GetFloat("BestTime", 0f);
        float last = PlayerPrefs.GetFloat("LastTime", 0f);

        bestText.text = "BestTime: " + best.ToString("F2") + "초";
        lastTimeText.text = "Time: " + last.ToString("F2") + "초";

        bestText.gameObject.SetActive(true);
        lastTimeText.gameObject.SetActive(true);
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //화면누르면 다시 게임으로 이동
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
