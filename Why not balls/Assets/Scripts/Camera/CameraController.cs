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
    Camera cam;

    // Start is called before the first frame update
    void Awake()
    {
        cam = GetComponent<Camera>();
        velocity = Vector3.zero;
        zoomVelocity = 0;

    }

    private void LateUpdate()
    {

        Vector3 target = new Vector3(bodyToFollow.position.x, bodyToFollow.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity, FollowSmoothTime);
        cam.fieldOfView = Mathf.SmoothDamp(cam.fieldOfView, bodyToFollow.velocity.magnitude, ref zoomVelocity, ZoomSmoothTime);
        
    }


}
