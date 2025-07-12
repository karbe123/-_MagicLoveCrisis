using System.Collections; // �ڷ�ƾ�Ἥ �ð� �ʰ� ��Ÿ���� �ϱ�
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

        bestText.text = "BestTime: " + best.ToString("F2") + "��";
        lastTimeText.text = "Time: " + last.ToString("F2") + "��";

        bestText.gameObject.SetActive(true);
        lastTimeText.gameObject.SetActive(true);
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //ȭ�鴩���� �ٽ� �������� �̵�
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
