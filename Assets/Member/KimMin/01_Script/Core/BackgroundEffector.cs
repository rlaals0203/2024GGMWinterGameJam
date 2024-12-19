using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundEffector : MonoSingleton<BackgroundEffector>
{
    [HideInInspector] public SpriteRenderer backgroundRenderer;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public SpriteRenderer GetBackground()
    {
        SpriteRenderer renderer = GameObject.Find("StageBackground").GetComponent<SpriteRenderer>();

        if (renderer != null) return renderer;

        return null;
    }

    public void ChangeBackgroundColor(Color color, float time)
    {
        if(backgroundRenderer == null)
            backgroundRenderer = GetBackground();

        Color origin = backgroundRenderer.color;

        backgroundRenderer.color = color;
        backgroundRenderer.DOColor(origin, time);
    }
}
