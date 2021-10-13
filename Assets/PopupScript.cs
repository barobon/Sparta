using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;

public class PopupScript : MonoBehaviour
{
    public static string nextScene = "GameScene";
    //로딩 씬으로 넘겨주기 위해 public static으로 선언

    void startBtnClicked()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        yield return null;
    }
}

