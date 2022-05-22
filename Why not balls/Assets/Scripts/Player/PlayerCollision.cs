using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameOverScreen GameOverScreen;
    public TimerController Timer;
    public PlayerMovement movementController;

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
                ScoreController.scoreValue += 1;
                Destroy(collider.gameObject);
                Timer.restartTimer();  
                movementController.RedirectUpwards();
                movementController.makeControllable();
                break;
            default:
                break;
        }
    }
    private void Die()
    {
        Time.timeScale = 0;
        GameOverScreen.Setup(ScoreController.scoreValue);
        Timer.Disable();
        ScoreController.restartScore();
        ScoreController.Disable();

        gameObject.SetActive(false);
    }

}