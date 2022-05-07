using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float maxForce = 5;
    public float minForce = 0;
    public float maxSpeed = 50;
    public float slowdownFactor = 0.05f;
    public Camera mainCamera;
    public TimeController timeController;
    Rigidbody2D myBody;
    Vector2 startPos, endPos;


    // Start is called before the first frame update
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();


    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            startPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            timeController.doSlowmotion(slowdownFactor);
        }
        if(Input.GetMouseButtonUp(0))
        {
            myBody.velocity = Vector2.zero;
            endPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector2 force = new Vector2(
                Mathf.Clamp(startPos.x - endPos.x, minForce, maxForce),
                Mathf.Clamp(startPos.y - endPos.y, minForce, maxForce));
            myBody.AddForce(force, ForceMode2D.Impulse);
            timeController.undoSlowmotion();
        }

    }
    void FixedUpdate()
    {
        myBody.velocity = Vector2.ClampMagnitude(myBody.velocity, maxSpeed);
    }


}
