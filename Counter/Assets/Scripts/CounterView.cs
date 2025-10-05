using UnityEngine;
using TMPro;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        _counter.CountChanged += Display;
    }

    private void OnDisable()
    {
        _counter.CountChanged -= Display;
    }

    public void Display()
    {
        float count = _counter.Count;
        _text.text = count.ToString("");
    }
}
