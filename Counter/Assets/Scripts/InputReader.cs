using System;
using System.Collections;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action MouseClick;

    private int _mouseButtonNumber = 0;

    void Update()
    {
        if (Input.GetMouseButtonDown(_mouseButtonNumber))
        {
            MouseClick?.Invoke();
        }
    }
}
