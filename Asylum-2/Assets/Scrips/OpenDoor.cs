using UnityEngine;

public enum RotationDirection
{
    X,
    Y,
    Z
}

public enum RotationSpace
{
    Global,
    Local
}

public class OpenDoor : MonoBehaviour
{
    public Transform door;
    public RotationDirection rotationDirection;
    public RotationSpace rotationSpace = RotationSpace.Local;
    public float rotationSpeed = 30f;
    public float maxRotationAngle = 90f;
    private bool isRotating = false;
    private float currentRotation = 0f;
    private int rotationDirectionSign = 1;

    public GameObject Zombie;

    private void Start()
    {
        door = GetComponent<Transform>();
    }

    private void Update()
    {
        if (isRotating)
        {
            float rotationAmount = rotationSpeed * Time.deltaTime * rotationDirectionSign;
            Vector3 rotationAxis = GetRotationAxis(rotationDirection);

            currentRotation += rotationAmount;
            currentRotation = Mathf.Clamp(currentRotation, 0f, maxRotationAngle); // Nuevo

            if (rotationSpace == RotationSpace.Local)
                door.Rotate(rotationAxis, rotationAmount);
            else
                door.Rotate(rotationAxis, rotationAmount, Space.World);

            if (currentRotation >= maxRotationAngle || currentRotation <= 0f)
            {
                isRotating = !isRotating;
                rotationDirectionSign *= -1;
            }
        }
    }
    private Vector3 GetRotationAxis(RotationDirection direction)
    {
        switch (direction)
        {
            case RotationDirection.X:
                return Vector3.right;
            case RotationDirection.Y:
                return Vector3.up;
            case RotationDirection.Z:
                return Vector3.forward;
            default:
                return Vector3.zero;
        }
    }
    private void OnMouseDown()
    {
        isRotating = !isRotating;

        /*if (Zombie != null)
        {
            AnimateButton receiver = Zombie.GetComponent<AnimateButton>();
            if (receiver != null)
            {
                receiver.ReceiveClick();
            }
        }*/
    }
}