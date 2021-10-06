using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    public float volume;

    private void Awake()
    {
        Instance = this;
    }
}
