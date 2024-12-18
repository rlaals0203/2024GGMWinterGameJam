using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool IsAwake { get; protected set; } = false;

    public float ShotPower = 100f;
    public ReleaseShot releaseShot;

    private Dictionary<Type, IPlayerComponent> _components;

    protected virtual void Awake()
    {
        _components = new Dictionary<Type, IPlayerComponent>();

        GetComponentsInChildren<IPlayerComponent>().ToList()
            .ForEach(x => _components.Add(x.GetType(), x));

        _components.Values.ToList().ForEach(compo => compo.Initialize(this));
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
