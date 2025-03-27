
using UnityEngine;

public interface IPlayerInput
{
    public bool IsFirePressed { get; }
    public Vector2 MoveDirection { get; }
    public Vector2 LookDirection { get; }
}