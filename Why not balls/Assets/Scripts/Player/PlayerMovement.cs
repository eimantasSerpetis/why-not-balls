using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(LineRenderer))]
public class PlayerMovement : MonoBehaviour
{
    public float maxForce = 5;
    public float minForce = 0;
    public float maxSpeed = 50;
    public float slowdownFactor = 0.05f;
    public int trjLinePointCount = 50;
    public Camera mainCamera;
    public TimeController timeController;
    Rigidbody2D myBody;
    LineRenderer lr;
    Vector2 startPos, endPos;


    // Start is called before the first frame update
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        lr = GetComponent<LineRenderer>();
        lr.enabled = false;


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
        if(Input.GetMouseButton(0))
        {
            endPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector2 force = new Vector2(
                Mathf.Clamp(startPos.x - endPos.x, minForce, maxForce),
                Mathf.Clamp(startPos.y - endPos.y, minForce, maxForce));
            //deal with trajectory
            Vector3[] trajectory = PlotForLine(myBody, transform.position, force, trjLinePointCount, slowdownFactor);
            lr.positionCount = trjLinePointCount;
            lr.SetPositions(trajectory);
            lr.enabled = true;

            
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
            lr.enabled = false;
        }

    }
    void FixedUpdate()
    {
        myBody.velocity = Vector2.ClampMagnitude(myBody.velocity, maxSpeed);
    }

    Vector3[] PlotForLine(Rigidbody2D myBody, Vector2 position, Vector2 velocity, int steps, float timeScale)
    {
        Vector3[] results = new Vector3[steps];
        float timestep = Time.fixedDeltaTime / timeScale / Physics2D.velocityIterations;
        // calculate the forces
        Vector2 gravityAcc = Physics2D.gravity * myBody.gravityScale * timestep * timestep;
        // curently not using drag, but calculate it just in case we use it
        float drag = 1f - timestep * myBody.drag;

        Vector2 moveStep = velocity * timestep;

        for(int i = 0; i < steps; i++)
        {
            moveStep += gravityAcc;
            moveStep *= drag;
            position += moveStep;
            results[i] = new Vector3(position.x, position.y, 0.5f);

        }
        return results;
    }


}
