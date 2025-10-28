using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraFollow : MonoBehaviour
{
    [Header("Follow Target")]
    public Transform target;      
    public float smoothSpeed = 5f;

    [Header("Camera Bounds")]
    public Vector2 minBounds;      
    public Vector2 maxBounds;      

    private Vector3 offset;       

    void Start()
    {
        TilemapCollider2D mapCollider = FindObjectOfType<TilemapCollider2D>();
        if (mapCollider != null)
        {
            Bounds bounds = mapCollider.bounds;
            minBounds = bounds.min;
            maxBounds = bounds.max;
        }

        if (target != null)
            offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        desiredPosition.z = transform.position.z;

        desiredPosition.x = Mathf.Clamp(desiredPosition.x, minBounds.x, maxBounds.x);
        desiredPosition.y = Mathf.Clamp(desiredPosition.y, minBounds.y, maxBounds.y);

        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * smoothSpeed);
    }
}
