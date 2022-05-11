using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Lava":
                Destroy(gameObject);
                break;
            case "SpikeBall":
                Destroy(gameObject);
                break;
            case "ScoreBall":
                Destroy(collision.gameObject);
                break;
            default:
                break;
        }
    }

}