using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public event Action CountChanged;

    public int Count {  get; private set; }

    private int _mouseButtonNumber = 0;
    private bool _isEnable = true;

    private void Start()
    {
        Count = 0;
        StartCoroutine(CounterWork());
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(_mouseButtonNumber) && _isEnable == true)
        {
            _isEnable = false;
            StopCoroutine(CounterWork());
        }
        else if (Input.GetMouseButtonDown(_mouseButtonNumber) && _isEnable == false)
        {
            _isEnable = true;
            StartCoroutine(CounterWork());
        }
    }

    private IEnumerator CounterWork()
    {
        float delay = 0.5f;

        while (_isEnable == true)
        {
            Count++;
            CountChanged?.Invoke();

            yield return new WaitForSecondsRealtime(delay);
        }
    }
}
