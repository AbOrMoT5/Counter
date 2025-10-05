using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    public event Action CountChanged;

    public int Count {  get; private set; }

    private bool _isEnable = true;

    private void OnEnable()
    {
        _inputReader.MouseClicked += OnMouseClick;
    }

    private void Start()
    {
        Count = 0;
        StartCoroutine(Work());
    }

    private void OnDisable()
    {
        _inputReader.MouseClicked -= OnMouseClick;
    }

    private void OnMouseClick()
    {
        if (_isEnable)
        {
            _isEnable = false;
            StopCoroutine(Work());
        }
        else
        {
            _isEnable = true;
            StartCoroutine(Work());
        }
    }

    private IEnumerator Work()
    {
        float delay = 0.5f;

        WaitForSecondsRealtime wait = new WaitForSecondsRealtime(delay);

        while (_isEnable == true)
        {
            Count++;
            CountChanged?.Invoke();

            yield return wait;
        }
    }
}
