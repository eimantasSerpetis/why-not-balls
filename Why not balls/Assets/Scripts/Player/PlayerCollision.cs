using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameOverScreen GameOverScreen;
    public int score = 0;
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