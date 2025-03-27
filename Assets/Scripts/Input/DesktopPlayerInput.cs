using System;
using UnityEngine;
using Zenject;

// if you want you can implement by new inut system and use Input actions + input axes
public class DesktopPlayerInput : IPlayerInput, IInitializable, ITickable, IDisposable
{
    private const string HORIZONTAL_AXIS = "Horizontal";
    private const string VERTICAL_AXIS = "Vertical";

    public bool IsFirePressed => Input.GetMouseButton(0);

    public Vector2 MoveDirection { get; private set; }

    public Vector2 LookDirection { get; private set; }

    private Vector2? _lastMousePosition;

    public void Initialize()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Dispose()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void Tick()
    {
        var horizontal = Input.GetAxis(HORIZONTAL_AXIS);
        var vertical = Input.GetAxis(VERTICAL_AXIS);

        MoveDirection = new Vector2(horizontal, vertical);

        var mousePosition = (Vector2)Input.mousePosition;
        if (_lastMousePosition.HasValue) // because i need to calculate delta position only after we receive first time mouse position
        {
            LookDirection = _lastMousePosition.Value - mousePosition;
        }
        _lastMousePosition = mousePosition;
    }
}
