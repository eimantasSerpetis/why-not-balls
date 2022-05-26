using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
                BallSpawner.scoreBallCount -= 1;
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
        StartCoroutine(ExecuteAfterTime(0.5f, () =>{ ChangeTime(); }));
        GameOverScreen.Setup(ScoreController.scoreValue);
        Timer.Disable();
        ScoreController.restartScore();
        ScoreController.Disable();

        gameObject.SetActive(false);
    }
    private bool isCoroutineExecuting = false;
    IEnumerator ExecuteAfterTime(float time, Action task)
    {
        if (isCoroutineExecuting)
            yield break;
        isCoroutineExecuting = true;
        yield return new WaitForSeconds(time);
        task();
        isCoroutineExecuting = false;
    }
    private void ChangeTime()
    {
        Time.timeScale = 0;
    }
}