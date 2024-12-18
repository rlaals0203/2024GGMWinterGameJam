using Cinemachine;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool IsAwake { get; protected set; } = false;
    public Transform CameraPos { get; protected set; }
    public PlayerVisual PlayerVisualCompo { get; protected set; }

    public float bulletSpeed = 10f;
    public float shotPower = 100f;

    public Vector3 moveDir;
    public ReleaseShot releaseShot;
    public SpriteRenderer cutScene;

    private Dictionary<Type, IPlayerComponent> _components;

    protected virtual void Awake()
    {
        _components = new Dictionary<Type, IPlayerComponent>();

        GetComponentsInChildren<IPlayerComponent>().ToList()
            .ForEach(x => _components.Add(x.GetType(), x));

        _components.Values.ToList().ForEach(compo => compo.Initialize(this));

        CameraPos = transform.Find("CameraPos");
        cutScene = transform.Find("CutScene").GetComponent<SpriteRenderer>();
        PlayerVisualCompo = GetCompo<PlayerVisual>();
    }

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
