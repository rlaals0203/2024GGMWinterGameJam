using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : PlayerSetting
{
    private Dictionary<Type, IPlayerComponent> _components;

    private void OnEnable()
    {
        releaseShot.OnShotEvent += HandleOnShot;
        WindController.Instance.OnWindChanged += HandleGravityChanged;
    }

    protected override void Awake()
    {
        base.Awake();

        _components = new Dictionary<Type, IPlayerComponent>();

        GetComponentsInChildren<IPlayerComponent>().ToList()
            .ForEach(x => _components.Add(x.GetType(), x));

        _components.Values.ToList().ForEach(compo => compo.Initialize(this));
    }

    private void HandleGravityChanged()
    {
        WindController.Instance.SetVelocity(RigidCompo);
    }

    private void HandleOnShot(Vector2 shotDir)
    {
        WindController.Instance.UpWind();

        IsAwake = true;
        RigidCompo.simulated = true;
        RigidCompo.AddForce(shotDir * 100);
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
