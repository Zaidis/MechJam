
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour, AxisState.IInputAxisProvider
{
    [HideInInspector]
    public InputAction right;
    [HideInInspector]
    public InputAction up;
    public float GetAxisValue(int axis)
    {
        switch (axis)
        {
            case 0:return right.ReadValue<Vector2>().x;
            case 1: return right.ReadValue<Vector2>().y;
            case 2: return right.ReadValue<float>();
        }
        return 0;
    }

}
