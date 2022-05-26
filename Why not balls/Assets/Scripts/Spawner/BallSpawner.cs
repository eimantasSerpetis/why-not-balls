 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 
 public class BallSpawner : MonoBehaviour
 {
    public int scoreBallsToPlace; //Count of score balls that will be spawned
    public int spikeBallsToPlace; //Count of spike balls that will be spawned
    public List<GameObject> balls; //List for ball types ("Spike Ball", "Score Ball)
    public GameObject quad; //Area in which balls can spawn
    public float ballCheckRadius; //Radius for collision checking
    public int maxSpawnAttemptsPerBall = 10; //Max attempts to spawn a ball to evade infinite loop
    public static int scoreBallCount; //Count of score balls that are existing in level
    public bool firstSpawn = true; //If true spawn both score and spike balls if false spawns only score balls and outside camera view
    public GameObject scoreBall;
 
    void Awake()
    {
        scoreBallCount = 0;
    }
    void Update()
    {
        GameObject Ball; //Ball object
        MeshCollider c = quad.GetComponent<MeshCollider>();
        float screenX, screenY; //Coordinates X and Y

        if(firstSpawn)
        {
            firstSpawn = false;
            for (int i = 0; i < balls.Count; i++)
            {
                Ball = balls[i];
                switch(Ball.tag)
                {
                    case "ScoreBall":
                        scoreBall = Ball;
                        for (int j = 0; j < scoreBallsToPlace; j++)
                        {
                            // Create a position variable
                            Vector2 position = Vector2.zero;
                
                            // whether or not we can spawn in this position
                            bool validPosition = false;
                
                            // How many times we've attempted to spawn this ball
                            int spawnAttempts = 0;
                
                            // While we don't have a valid position 
                            //  and we haven't tried spawning this obstable too many times
                            while(!validPosition && spawnAttempts < maxSpawnAttemptsPerBall)
                            {
                                // Increase our spawn attempts
                                spawnAttempts++;

                                //Assign random position
                                screenX = Random.Range(c.bounds.min.x, c.bounds.max.x);
                                screenY = Random.Range(c.bounds.min.y, c.bounds.max.y);
                                position = new Vector2(screenX, screenY);

                                // This position is valid until proven invalid
                                validPosition = true;
                
                                // Collect all colliders within our Ball Check Radius
                                Collider2D[] colliders = Physics2D.OverlapCircleAll(position, ballCheckRadius);
                
                                // Go through each collider collected
                                foreach(Collider2D col in colliders)
                                {
                                    // If this collider is tagged "SpikeBall" or "ScoreBall" or "StartZone"
                                    if(col.tag == "SpikeBall" || col.tag == "ScoreBall" || col.tag == "StartZone")
                                    {
                                        // Then this position is not a valid spawn position
                                        validPosition = false;
                                    }
                                }
                            }

                            // If we exited the loop with a valid position
                            if(validPosition)
                            {
                                // Spawn the ball here
                                Instantiate(Ball, position, Quaternion.identity);
                                scoreBallCount += 1;
                            }
                        }
                        break;
                    case "SpikeBall":
                        for (int j = 0; j < spikeBallsToPlace; j++)
                        {
                            // Create a position variable
                            Vector2 position = Vector2.zero;
                
                            // whether or not we can spawn in this position
                            bool validPosition = false;
                
                            // How many times we've attempted to spawn this ball
                            int spawnAttempts = 0;
                
                            // While we don't have a valid position 
                            //  and we haven't tried spawning this obstable too many times
                            while(!validPosition && spawnAttempts < maxSpawnAttemptsPerBall)
                            {
                                // Increase our spawn attempts
                                spawnAttempts++;

                                //Assign random position
                                screenX = Random.Range(c.bounds.min.x, c.bounds.max.x);
                                screenY = Random.Range(c.bounds.min.y, c.bounds.max.y);
                                position = new Vector2(screenX, screenY);

                                // This position is valid until proven invalid
                                validPosition = true;
                
                                // Collect all colliders within our Ball Check Radius
                                Collider2D[] colliders = Physics2D.OverlapCircleAll(position, ballCheckRadius);
                
                                // Go through each collider collected
                                foreach(Collider2D col in colliders)
                                {
                                    // If this collider is tagged "SpikeBall" or "ScoreBall" or "StartZone"
                                    if(col.tag == "SpikeBall" || col.tag == "ScoreBall" || col.tag == "StartZone")
                                    {
                                        // Then this position is not a valid spawn position
                                        validPosition = false;
                                    }
                                }
                            }
                
                            // If we exited the loop with a valid position
                            if(validPosition)
                            {
                                // Spawn the ball here
                                Instantiate(Ball, position, Quaternion.identity);
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        else
        {
            if(scoreBallCount <= scoreBallsToPlace / 5)
            {
                for (int j = 0; j < scoreBallsToPlace - scoreBallsToPlace / 5; j++)
                {
                    // Create a position variable
                    Vector2 position = Vector2.zero;
        
                    // whether or not we can spawn in this position
                    bool validPosition = false;
        
                    // How many times we've attempted to spawn this ball
                    int spawnAttempts = 0;
        
                    // While we don't have a valid position 
                    //  and we haven't tried spawning this obstable too many times
                    while(!validPosition && spawnAttempts < maxSpawnAttemptsPerBall)
                    {
                        // Increase our spawn attempts
                        spawnAttempts++;

                        //Assign random position
                        screenX = Random.Range(c.bounds.min.x, c.bounds.max.x);
                        screenY = Random.Range(c.bounds.min.y, c.bounds.max.y);
                        position = new Vector2(screenX, screenY);

                        // This position is valid until proven invalid
                        validPosition = true;
        
                        // Collect all colliders within our Ball Check Radius
                        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, ballCheckRadius);
        
                        // Go through each collider collected
                        foreach(Collider2D col in colliders)
                        {
                            // If this collider is tagged "SpikeBall" or "ScoreBall" or "StartZone"
                            if(col.tag == "SpikeBall" || col.tag == "ScoreBall" || col.tag == "StartZone" || col.tag == "MainCamera")
                            {
                                // Then this position is not a valid spawn position
                                validPosition = false;
                            }
                        }
                    }

                    // If we exited the loop with a valid position
                    if(validPosition)
                    {
                        // Spawn the ball here
                        Instantiate(scoreBall, position, Quaternion.identity);
                        scoreBallCount += 1;
                    }
                }
            }
        }
    }
}