using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoSingleton<StageManager>
{
    public int currentStage;
    public event Action OnStageLoaded;

    public void LoadStage()
    {
        SceneManager.LoadScene($"Stage{currentStage}");

        OnStageLoaded?.Invoke();
    }
}