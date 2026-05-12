using UnityEngine;

public class NewComponent1 : MonoBehaviour
{
    Vector3 valueToMove = new Vector3(0, 0, 0.01f);
    Vector3 rotationMovement = new Vector3(0, 0.1f, 0);
    float rotationLimit = 180f;
    void Update()
    {
        transform.localPosition += valueToMove;
        
        if (transform.localPosition.z > 5f || transform.localPosition.z < -5f)
        {
            valueToMove.z *= -1;
        }

        transform.Rotate(rotationMovement, Space.Self);
        float currentYRotation = transform.localEulerAngles.y;
        if (currentYRotation > 180) currentYRotation -= 360;
        
        if (currentYRotation > rotationLimit || currentYRotation < -rotationLimit)
        {
            rotationMovement.y *= -1;
        }
    }
}
