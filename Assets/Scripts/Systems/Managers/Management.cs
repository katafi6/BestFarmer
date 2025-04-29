using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Management : MonoBehaviour
{
    private static Management _instance;

    public static Management Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Management>();
                if (_instance == null)
                {
                    GameObject managementObj = new GameObject("Management");
                    _instance = managementObj.AddComponent<Management>();
                    return _instance;
                }
            }

            return _instance;
        }
    }

    private Dictionary<Type, ManagerBase> _managers = new Dictionary<Type, ManagerBase>();

    private void Awake()
    {
        if (_instance != null)
        {
            DestroyImmediate(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);

        foreach (var manager in GetComponentsInChildren<ManagerBase>())
        {
            Type managerType = manager.GetType();
            if (_managers.ContainsKey(managerType))
                continue;

            RegistryManager<ManagerBase>();
        }
    }

    private void RegistryManager<T>() where T : ManagerBase
    {
        T manager = GetComponentInChildren<T>();
        if (manager == null)
        {
            GameObject managerObj = new GameObject(typeof(T).Name);
            managerObj.transform.SetParent(transform);
            manager = managerObj.AddComponent<T>();
        }

        _managers.Add(typeof(T), manager);
    }

    public void ReleaseManager<T>() where T : ManagerBase
    {
        if (!_managers.ContainsKey(typeof(T)))
            return;

        T manager = _managers[typeof(T)] as T;
        
        _managers.Remove(typeof(T));
        Destroy(manager?.gameObject);
    }

    public ManagerBase GetManager<T>() where T : ManagerBase
    {
        if (!_managers.ContainsKey(typeof(T)))
        {
            RegistryManager<T>();
        }

        return _managers[typeof(T)];
    }
}