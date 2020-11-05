using System;
using UnityEngine;
using UnityEngine.Events;

public class UnityEventExposer : MonoBehaviour
{
    [SerializeField] private UnityEvent OnStartEvent;
    [SerializeField] private UnityEvent OnAwakeEvent;
    [SerializeField] private UnityEvent OnEnableEvent;
    [SerializeField] private UnityEvent OnDisableEvent;

    private void Awake()
    {
        OnAwakeEvent?.Invoke();
    }

    private void OnEnable()
    {
        OnEnableEvent?.Invoke();
    }

    private void Start()
    {
        OnStartEvent?.Invoke();
    }

    private void OnDisable()
    {
        OnDisableEvent?.Invoke();
    }
}