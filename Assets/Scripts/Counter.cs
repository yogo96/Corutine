using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counterText;
    [SerializeField] private Button _button;
    [SerializeField] private float _period = 0.5f;
    [SerializeField] private int _counterTick = 1;
    [SerializeField] private bool _isActive = false;

    private int _startCounterValue = 0;
    private WaitForSeconds _delay;
    private void Start()
    {
        _delay = new WaitForSeconds(_period);
        _counterText.text = _startCounterValue.ToString();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(TakeCount);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(TakeCount);
    }

    private void TakeCount()
    {
        _isActive = !_isActive;
        StartCoroutine(CountTicks(_isActive));
       
    }

    private IEnumerator CountTicks(bool isRunning)
    {
        while (isRunning)
        {
            int previousValue = int.Parse(_counterText.text);
            int currentValue = previousValue + _counterTick;
            _counterText.text = currentValue.ToString();

            isRunning = _isActive;
            yield return _delay;
        }
    }
}
