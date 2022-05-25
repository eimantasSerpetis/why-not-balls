using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameOverScreen GameOverScreen;
    public TimerController Timer;
    public PlayerMovement movementController;
    public GameObject scoreBallExplosion;
    public GameObject playerExplosion;

    private Rigidbody2D rb;
    AudioManager audioManager;
    void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        switch (collider.gameObject.tag)
        {
            case "Lava":
                audioManager.Play("Die");
                Instantiate(playerExplosion, transform.position, transform.rotation);
                Die();
                break;
            case "SpikeBall":
                audioManager.Play("Die");
                Instantiate(playerExplosion, transform.position, transform.rotation);
                Die();
                break;
            case "ScoreBall":
                audioManager.Play("Score");
                ScoreController.scoreValue += 1;
                Instantiate(scoreBallExplosion, collider.gameObject.transform.position, collider.gameObject.transform.rotation);
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