using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    public Rigidbody2D bodyToFollow;
    public float FollowSmoothTime = 0.3f;
    public float ZoomSmoothTime = 0.5f;
    public float maxFOV;
    private Vector3 velocity;
    private float zoomVelocity;
    private float minSize;
    public float maxSize;
    Camera cam;

    // Start is called before the first frame update
    void Awake()
    {
        cam = GetComponent<Camera>();
        velocity = Vector3.zero;
        zoomVelocity = 0;
        minSize = cam.orthographicSize;


    }



    private void LateUpdate()
    {

        Vector3 target = new Vector3(bodyToFollow.position.x, bodyToFollow.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity, FollowSmoothTime);
        cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, map(bodyToFollow.velocity.magnitude, 0, 25, minSize, maxSize) , ref zoomVelocity, ZoomSmoothTime);
        //cam.orthographicSize = Mathf.Lerp (minZoom, maxZoom, Mathf.InverseLerp (0.0f, 50, bodyToFollow.velocity.magnitude));

    }

    public static float map(float value, float leftMin, float leftMax, float rightMin, float rightMax)
    {
        return rightMin + (value - leftMin) * (rightMax - rightMin) / (leftMax - leftMin);
    }


}
