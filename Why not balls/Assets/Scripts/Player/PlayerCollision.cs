using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameOverScreen GameOverScreen;
    public int score = 0;
    public float yForceCoeficient = 1f;
    public float xForceCoeficient = 0.5f;
    public float minBounceForceY = 10;
    public float maxBounceForceY = 15;

    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        switch (collider.gameObject.tag)
        {
            case "Lava":
                Die();
                break;
            case "SpikeBall":
                Die();
                break;
            case "ScoreBall":
                score += 1;
                Destroy(collider.gameObject);
                
                // On collision with the score ball, redirect velocity more upwards
                Vector2 tempVel = rb.velocity;
                float velY = tempVel.magnitude * yForceCoeficient;
                velY = Mathf.Clamp(velY, minBounceForceY, maxBounceForceY);
                Vector2 newVel = new Vector2(xForceCoeficient * tempVel.x, 0) + new Vector2(0, velY);
                rb.velocity = newVel;


                break;
            default:
                break;
        }
    }
    private void Die()
    {
        Time.timeScale = 0;
        GameOverScreen.Setup(score);
        gameObject.SetActive(false);
    }

}