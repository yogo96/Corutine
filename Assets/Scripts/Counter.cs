using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textHandler;
    [SerializeField] private Button _button;
    [SerializeField] private float _period = 0.5f;
    [SerializeField] private int _tickSize = 1;
    [SerializeField] private bool _isActive = false;

    private int _startTickValue = 0;
    private WaitForSeconds _delay;
    private Coroutine _coroutine;

    private void Start()
    {
        _delay = new WaitForSeconds(_period);
        _textHandler.text = _startTickValue.ToString();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(TakeTicks);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(TakeTicks);
    }

    private void Restart()
    {
        _coroutine = StartCoroutine(CountTicks());
    }
    
    private void Stop()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private void TakeTicks()
    {
        if (_isActive)
        {
            Stop();
        }
        else
        {
            Restart();
        }
        _isActive = !_isActive;
    }

    private IEnumerator CountTicks()
    {
        while (true)
        {
            int previousValue = int.Parse(_textHandler.text);
            int currentValue = previousValue + _tickSize;
            _textHandler.text = currentValue.ToString();

            yield return _delay;
        }
    }
}