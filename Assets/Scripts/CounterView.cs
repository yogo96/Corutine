using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textHandler;
    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        _counter.CounterChanged += UpdateView;
    }

    private void OnDisable()
    {
        _counter.CounterChanged -= UpdateView;
    }

    private void UpdateView(int value)
    {
        _textHandler.text = value.ToString();
    }
}
