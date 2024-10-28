using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public event Action<int> ChangeCounter;

    [SerializeField] private float _durationTime = 0.5f;
    
    private int _currentValue;
    private WaitForSeconds _delay;
    private Coroutine _coroutine;
    private bool _isActive;

    private void Start()
    {
        _currentValue = 0;
        ChangeCounter?.Invoke(_currentValue);
        _isActive = false;
        _delay = new WaitForSeconds(_durationTime);
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (_isActive == false)
            {
                Restart();
            }
            else
            {
                Stop();
            }
        }
    }

    private void Restart()
    {
        _isActive = true;
        _coroutine = StartCoroutine(StartCounting());
    }

    private void Stop()
    {
        _isActive = false;

        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private IEnumerator StartCounting()
    {
        while (_isActive)
        {
            _currentValue++;
            ChangeCounter?.Invoke(_currentValue);
            yield return _delay;
        }
    }
}