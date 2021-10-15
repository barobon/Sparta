using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;

public class PopupScript : MonoBehaviour
{
    private string nextScene = "GameScene";

    private void Awake()
    {
        closePopup();
    }
    public void startBtnClicked()
    {
        LoadingManager.LoadScene(nextScene);
    }

    public void closePopup()
    {
        this.gameObject.SetActive(false);   //�˾� ��Ȱ��ȭ
    }

    public void openPopup()
    {
        this.gameObject.SetActive(true);
    }

}

