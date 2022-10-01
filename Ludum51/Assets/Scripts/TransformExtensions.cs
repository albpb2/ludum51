using UnityEngine;

public static class TransformExtensions
{
    public static void RotateStepTowards(this Transform transform, Vector3 targetPosition)
    {
        Vector3 targetDirection = targetPosition - transform.position;
        const int rotationSpeed = 5;
        float singleStep = rotationSpeed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
}