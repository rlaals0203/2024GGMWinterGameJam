using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Transform CameraPos { get; protected set; }
    public PlayerVisual PlayerVisualCompo { get; protected set; }

    public float bulletSpeed = 10f;
    public float shotPower = 100f;

    public Vector3 moveDir;
    public ReleaseShot releaseShot;
    public SpriteRenderer cutScene;

    public Transform startPos;

    private Dictionary<Type, IPlayerComponent> _components;

    protected virtual void Awake()
    {
        _components = new Dictionary<Type, IPlayerComponent>();

        GetComponentsInChildren<IPlayerComponent>().ToList()
            .ForEach(x => _components.Add(x.GetType(), x));

        _components.Values.ToList().ForEach(compo => compo.Initialize(this));

        StageManager.Instance.OnStageLoaded += HandleStageLoad;

        CameraPos = transform.Find("CameraPos");
        cutScene = transform.Find("CutScene").GetComponent<SpriteRenderer>();
        PlayerVisualCompo = GetCompo<PlayerVisual>();
    }

    private void HandleStageLoad()
    {
        while (GetSceneName() == $"Stage{StageManager.Instance.currentStage}")
        {
            break;
        }

        startPos = GameObject.Find("StartPos").transform;
    }

    private string GetSceneName() => SceneManager.GetActiveScene().name;

    public T GetCompo<T>() where T : class
    {
        Type type = typeof(T);
        if (_components.TryGetValue(type, out IPlayerComponent component))
        {
            return component as T;
        }
        return default;
    }
}
