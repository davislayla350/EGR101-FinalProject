using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private void Start()
    {
        if (target == null)
        {
            target = GameObject.Find("Frog").transform; //assign target from camera to follow
        }
    }

    [SerializeField] private Transform target;
    [SerializeField, Range(0.01f, 1f)]
    private float smoothSpeed = 0.125f;

    [SerializeField] private Vector3 offset;

    private Vector3 velocity = Vector3.zero;

    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
    }
}
