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
        //외부 함수에서 접근 가능하게 public static으로 선언
        nextScene = sceneName;
        EditorSceneManager.LoadScene("LoadingScene");   
    }

    IEnumerator LoadScene()
    {
        yield return null;  //1프레임 대기, 1프레임 동안 제어권을 유니티에 넘겨줌

        AsyncOperation oper = EditorSceneManager.LoadSceneAsync(nextScene); //다음 씬을 동기적으로 호출
        oper.allowSceneActivation = false;  // 로딩이 95%에서 멈추도록 설정, 다음씬으로 바로 이동하지 않음

        while (!oper.isDone)
        {
            //로딩이 끝나지 않으면 계속 실행
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
