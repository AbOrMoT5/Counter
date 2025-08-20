using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private int _count = 0;
    private bool _isEnable = true;

    private void Start()
    {
        _text.text = "0";
        StartCoroutine(CounterWork());
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _isEnable == false)
        {
            _isEnable = true;
            StartCoroutine(CounterWork());
        }
        else if (Input.GetMouseButtonDown(0) && _isEnable == true)
        {
            _isEnable = false;
        }
    }

    private IEnumerator CounterWork()
    {
        float delay = 0.5f;
        var wait = new WaitForSecondsRealtime(delay);

        while (_isEnable == true)
        {
            _count++;
            _text.text = _count.ToString("");

            yield return wait;
        }
    }
}
