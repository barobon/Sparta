using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;

public class LoadingManager : MonoBehaviour
{
    public static string nextScene;
    [SerializeField] Image loadingBar;

    void Start()
    {
        StartCoroutine(LoadScene());
    }

    public static void LoadScene(string sceneName)
    {
        //�ܺ� �Լ����� ���� �����ϰ� public static���� ����
        nextScene = sceneName;
        EditorSceneManager.LoadScene("LoadingScene");   
    }

    IEnumerator LoadScene()
    {
        yield return null;  //1������ ���, 1������ ���� ������� ����Ƽ�� �Ѱ���

        AsyncOperation oper = EditorSceneManager.LoadSceneAsync(nextScene); //���� ���� ���������� ȣ��
        oper.allowSceneActivation = false;  // �ε��� 95%���� ���ߵ��� ����, ���������� �ٷ� �̵����� ����

        while (!oper.isDone)
        {
            //�ε��� ������ ������ ��� ����
            yield return null;

            if (oper.progress < 0.9f)
            {
                loadingBar.fillAmount = oper.progress;
                yield return null;
            }
            else
            {
                loadingBar.fillAmount = 1.0f;
                oper.allowSceneActivation = true;
                yield break;
            }
        }

        

        
    }
}
