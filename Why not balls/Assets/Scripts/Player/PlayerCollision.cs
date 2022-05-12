using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameOverScreen GameOverScreen;
    public int score = 11;
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Lava"))
        {
            Die();
            //Destroy(gameObject);
        }
    }
    private void Die()
    {
        Time.timeScale = 0;
        gameObject.SetActive(false);
        GameOverScreen.Setup(score);
    }

}