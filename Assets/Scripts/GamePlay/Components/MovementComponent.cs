using R3;
using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    [SerializeField]
    private CharacterController _characterController;
    public readonly ReactiveProperty<float> CurrentSpeed = new ReactiveProperty<float>();
    public readonly ReactiveProperty<float> MaxSpeed = new ReactiveProperty<float>();
    public void Setup(float speed, float maxSpeed)
    {
        CurrentSpeed.Value = speed;
        MaxSpeed.Value = maxSpeed;
        //_characterController.
    }

    public void Move(Vector2 direction)
    {
        var moveDirection = new Vector3(direction.x, 0, direction.y) * CurrentSpeed.Value;
        _characterController.SimpleMove(moveDirection);
    }
}