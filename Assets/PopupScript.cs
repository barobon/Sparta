using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;

public class PopupScript : MonoBehaviour
{
    public static string nextScene = "GameScene";
    //�ε� ������ �Ѱ��ֱ� ���� public static���� ����

    void startBtnClicked()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        yield return null;
    }
}

