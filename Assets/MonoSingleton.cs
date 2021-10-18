using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : Component
{
//where은 제네릭 형식 제약 조건
//T는 Component 형식이어야 한다

    protected static T _instance;   //안전성을 위한 변수

    public static T Instance        // 변수의 값을 쉽게 가져올 수 있는 접근자(property)
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();
                if (_instance == null)
                {
                    GameObject obj = new GameObject();
                    _instance = obj.AddComponent<T>();
                }
            }
            return _instance;
        }
    }

    protected virtual void Awake()
    {
        if (!Application.isPlaying)
        {
            return;
        }

        _instance = this as T;
    }
}