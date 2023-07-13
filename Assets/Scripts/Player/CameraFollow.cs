using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    #region EXPOSED_FIELDS
    [SerializeField] private Transform target = null;         
    [SerializeField] private float smoothSpeed = 0.125f;
    [SerializeField] private Vector3 offset = default;
    #endregion

    #region UNITY_CALLS
    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
    #endregion
}
