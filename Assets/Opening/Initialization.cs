using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initialization : MonoBehaviour
{
    private static bool isInitialized = false; // ����ʱ�ȭ�ϱ�

    void Awake()
    {
        if (!isInitialized)
        {
            isInitialized = true;

            // ���⼭ 1ȸ�ʱ��l
            PlayerPrefs.DeleteKey("BestTime");
            PlayerPrefs.Save();
            Debug.Log("�ְ��� �ʱ�ȭ �Ϸ�");
        }
    }
}
