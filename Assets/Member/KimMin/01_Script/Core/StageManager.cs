using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoSingleton<StageManager>
{
    public int currentStage;
    public bool isLoading = false;
    public event Action OnStageLoaded;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void LoadStage()
    {
        isLoading = true;
        currentStage++;
        SceneManager.LoadScene($"Stage{currentStage}");

        OnStageLoaded?.Invoke();
    }
}
