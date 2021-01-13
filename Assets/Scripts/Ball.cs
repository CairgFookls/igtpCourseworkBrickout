using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    //Written By Craig Foulkes
    //Last Updated 11/01/2021

    // Declares variables and Initialises them.
    float speed = 0.03f;
    float directionY = 2.0f;
    float directionX = 1.3f;

    int totalPoints = 0;
    int points = 0;
    int lives = 3;
    

    // Declares text UI variables.
    public Text pointTracker;
    public Text liveTracker;

    // Sets the text that displays points text portion of the UI to display "points: 0" on startup
    void Start()
    {
        pointTracker.text = "Points:" + points.ToString();
        liveTracker.text = "Lives:" + lives.ToString();
    }

    // Updates the position of the ball
    void FixedUpdate()
    {

        Vector3 position = transform.localPosition;
        position.y -= speed * directionY;
        position.x += speed * directionX;
        transform.localPosition = position;
      
    }

    // Ball Collision detection
    void OnCollisionEnter2D(Collision2D other)
    {
        // Sets the properties of collisions of the 4 walls and the bat
        switch (other.gameObject.name)
        {
            // Causes the ball's Y direction to reverse after colliding with the top wall or the bat
            case "Bat":
            case "Wall (top)":
                directionY = -directionY;
                break;
            
            // Causes the ball's X direction to reverse after colliding with the side walls
            case "Wall (right)":
            case "Wall (left)":
                directionX = -directionX;
                break;
            
            // resets the balls position and direction as well as reduces the number of lives after colliding with the kill box. When the player runs out of lives, the ball is deleted and the life tracking text displays "Game Over!"
            case "Kill box":
                transform.position = new Vector3(0, -2, 0);
                directionY = 2.0f;
                directionX = 1.3f;

                lives -= 1;
                liveTracker.text = "Lives:" + lives.ToString();

                if (lives == 0)
                {
                    liveTracker.text = "Game Over!";
                    Destroy(gameObject);
                }
                break;

            
        }

        // If the ball collides with a brick, the brick is destroyed, the ball's Y direction is reversed and points are added to the player's total, displaying on the Points text portion of the UI.
        // Hitting a brick also increases the speed variable of the ball, making the ball go faster the further you progress.
        // Destroying all of the bricks deletes the ball and sets the life tracking text to display "You Won!"
        if(other.gameObject.tag == "Brick")
        {
            Destroy(other.gameObject);
            directionY = -directionY;

            speed += 0.0005f; 

            AddPoints(10);

            if (totalPoints == 440)
            {
                liveTracker.text = "You Won!";
                Destroy(gameObject);
            }
        }

    }

    // adds points to the player's point total when called
    void AddPoints(int points)
    {
        totalPoints += points;
        pointTracker.text = "Points:" + totalPoints.ToString();
    }

}
