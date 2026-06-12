using UnityEngine;

public class ARInteraction : MonoBehaviour
{
    [Header("ZOOM")]
    public float zoomSpeed = 0.0015f;
    public float minScale = 0.3f;
    public float maxScale = 1.5f;

    [Header("ROTATE")]
    public float rotateSpeed = 0.2f;
    public float smoothSpeed = 5f;

    private Vector3 targetScale;
    private float rotationY;

    void Start()
    {
        targetScale = transform.localScale;
        rotationY = transform.eulerAngles.y;
    }

    void Update()
    {
        HandleZoom();
        HandleRotate();

        // Smooth scaling
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * smoothSpeed);

        // Smooth rotation
        Quaternion targetRotation = Quaternion.Euler(0, rotationY, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * smoothSpeed);
    }

    void HandleZoom()
    {
        if (Input.touchCount == 2)
        {
            Touch t1 = Input.GetTouch(0);
            Touch t2 = Input.GetTouch(1);

            Vector2 prevT1 = t1.position - t1.deltaPosition;
            Vector2 prevT2 = t2.position - t2.deltaPosition;

            float prevDist = (prevT1 - prevT2).magnitude;
            float currentDist = (t1.position - t2.position).magnitude;

            float diff = prevDist - currentDist; // FIX biar ga kebalik

            targetScale += Vector3.one * diff * zoomSpeed;

            targetScale = new Vector3(
                Mathf.Clamp(targetScale.x, minScale, maxScale),
                Mathf.Clamp(targetScale.y, minScale, maxScale),
                Mathf.Clamp(targetScale.z, minScale, maxScale)
            );
        }
    }

    void HandleRotate()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                float delta = touch.deltaPosition.x;
                rotationY += delta * rotateSpeed;
            }
        }
    }
}