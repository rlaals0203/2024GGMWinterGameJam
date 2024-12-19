using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    protected event Action OnSceneLoadComplete;

    public bool CanShot { get; protected set; } = true;
    public Transform CameraPos { get; protected set; }
    public PlayerVisual VisualCompo { get; protected set; }

    public ReleaseShot releaseShot;
    public Transform gunTrm;

    [HideInInspector] public Vector3 moveDir;
    [HideInInspector] public SpriteRenderer cutScene;
    [HideInInspector] public Transform startPos;

    public float bulletSpeed = 10f;
    public float shotPower = 100f;

    private Dictionary<Type, IPlayerComponent> _components;

    protected virtual void Awake()
    {
        _components = new Dictionary<Type, IPlayerComponent>();

        GetComponentsInChildren<IPlayerComponent>().ToList()
            .ForEach(x => _components.Add(x.GetType(), x));

        _components.Values.ToList().ForEach(compo => compo.Initialize(this));

        StageManager.Instance.OnStageLoaded += HandleStageLoad;

        gunTrm = GameObject.Find("Gun").transform;
        CameraPos = transform.Find("CameraPos");
        cutScene = transform.Find("CutScene").GetComponent<SpriteRenderer>();
        VisualCompo = GetCompo<PlayerVisual>();
    }

    private void HandleStageLoad()
    {
        Debug.Log(StageManager.Instance.currentStage);

        if($"Stage{StageManager.Instance.currentStage}" != GetSceneName())
        {
            SceneManager.LoadScene($"Stage{StageManager.Instance.currentStage}");
        }

        StageManager.Instance.isLoading = false;
        startPos = GameObject.Find("Gun").transform;
        OnSceneLoadComplete?.Invoke();
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
