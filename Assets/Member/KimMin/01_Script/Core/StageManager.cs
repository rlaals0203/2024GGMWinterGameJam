using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoSingleton<StageManager>
{
    public int currentStage;
    public int maxStage;
    public bool isLoading = false;
    public event Action OnStageLoaded;
    public string saveName = "maxStage";

    private void Awake()
    {
        DontDestroyOnLoad(this);
        maxStage = PlayerPrefs.GetInt(saveName);
    }

    public void LoadStage()
    {
        isLoading = true;
        currentStage++;

        if (currentStage > 8)
        {
            currentStage = 8;
        }

        if (currentStage > maxStage)
        {
            maxStage = currentStage;
            PlayerPrefs.SetInt(saveName, maxStage);
        }

        SceneManager.LoadScene($"Stage{currentStage}");

        OnStageLoaded?.Invoke();
    }
}
