using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private int _mouseButtonNumber = 0;

    public event Action MouseClicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_mouseButtonNumber))
        {
            MouseClicked?.Invoke();
        }
    }
}
