using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initialization : MonoBehaviour
{
    private static bool isInitialized = false; // 기록초기화하긔

    void Awake()
    {
        if (!isInitialized)
        {
            isInitialized = true;

            // 여기서 1회초기홯
            PlayerPrefs.DeleteKey("BestTime");
            PlayerPrefs.Save();
            Debug.Log("최고기록 초기화 완료");
        }
    }
}
