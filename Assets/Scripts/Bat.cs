using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class Bat : MonoBehaviour
{
    //Written by Craig Foulkes
    //Last updated 11/01/21

    // initialises speed and direction variables
    public float speed = 0.02f;
    float direction = 0.0f;

    // Initialises left and right movement key codes to the A and D key respectively
    public KeyCode moveLeftKey = KeyCode.A;
    public KeyCode moveRightKey = KeyCode.D;

    // Initialises boolean variables to true
    bool canMoveLeft = true;
    bool canMoveRight = true;


    // Updates the position of the bat.
    void FixedUpdate()
    {
        Vector3 position = transform.localPosition;
        position.x += speed * direction;
        transform.localPosition = position;
    }


    //updates the direction variable depending on player input, causing the bat to move left or right (assuming the bat hasn't collided with a side wall) or stay still.
    void Update()
    {

        bool isLeftPressed = Input.GetKey(moveLeftKey);
        bool isRightPressed = Input.GetKey(moveRightKey);

        if (isLeftPressed && canMoveLeft)
        {
            direction = -1.0f;
        }
        else if (isRightPressed && canMoveRight)
        {
            direction = 1.0f;
        }
        else
        {
            direction = 0.0f;
        }
    }

    // When the bat collides with a side wall, this code renders the bat unable to move any further in the direction of the wall it has collided with.
    void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.gameObject.name)
        {
            case "Wall (left)":
                canMoveLeft = false;
                break;

            case "Wall (right)":
                canMoveRight = false;
                break;
        }
    }

    // When the bat no longer makes contact with a side wall, it is able to travel in the direction of the side wall it collided with once again.
    void OnCollisionExit2D(Collision2D other)
    {
        switch (other.gameObject.name)
        {
            case "Wall (left)":
                canMoveLeft = true;
                break;

            case "Wall (right)":
                canMoveRight = true;
                break;
        }
    }
}
