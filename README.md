# igtpCourseworkBrickout
Craig Foulkes
S2033070
Computer Games Design
I confirm that the code contained in this file (other than that provided or authorised) is all my own work and has not been submitted elsewhere in fulfilment of any other award.
Signed: Craig Foulkes

#########
CONTENTS:
#########

General documentation of the Ball script: Line 22

General documentation of the Bat script: Line 33

Challenging Aspect of the Code: line 40

###########################
GENERAL DESRICPTION OF CODE
###########################

The Ball Script

The Ball script contains the code for the movement of the ball, the behaviour of the ball when it collides with other objects, as well as win and lose conditions.
The Ball has an inital x and y direction, that is multiplied with the variable 'speed' to create a vector. when the ball collides with either side wall, the x direction becomes negative and thus travels in the opposite direction. when it hits a brick, the bat or the top wall, its y direction becomes negative and thus travels in the opposite direction.

When the ball hits a brick, the brick is destroyed and the function 'AddPoints' is called on, which adds 10 points to the variable 'totalPoints', displayed on screen via the 'Points' UI object. When 'totalPoints' reaches a value of 440, the ball object is deleted and the 'Lives' UI object displays 'You Won!'. Additionally, every time the ball hits a break, the 'speed' variable increases, meaning that the ball moves faster after destroying a brick.

When the ball hits the bottom wall, dubbed the 'Kill box', it will transform the ball's position back to its starting position, reset the ball's direction variables (but not the speed variable) and reduce the 'lives' variable by one. if the 'lives' variable reaches 0, the ball object is deleted and the 'Lives' UI object displays 'Game Over'.



The Bat Script

The Bat script contains the code for the movement of the bat via player input. since the bat will only travel along the x axis, a y value for its direction is not necessary.

The script uses the a and d keys to move left and right respectively. pressing A will set the boolean variable "isLeftPressed" to true, pressing D would set "isRightPressed" to true. The script constantly checks if either boolean value is true. if "isLeftPressed" is true it will set the 'direction' variable (which is used in the vector to move the bat) to -1.0f, meaning it will travel left. the same is true for "isRightPressed", except it sets the variable to 1.0f, meaning it will move right. 

##########################
CHALLENGING ASPECT OF CODE
##########################

Trying to implement game over conditions proved rather challenging. At first I tried to create an object that would spawn in a new ball after the first one was destroyed. This would be difficult to implement as I would have to write a function in a new script that would be called on through the ball script as the collision detection is inside of the ball script. This means that I would either have to attach the script to the kill box object and have the ball spawn at a set location above the bat, or I would have to come up with an alternate solution. I had then decided I wouldn't need to write another script at all, nor would I have to delete the ball. I instead made an addition to the ball script so that when the ball collides with the kill box, the ball would teleport back to its original position and its direction would be reset, the lives variable would reduce by one each time it collides with the kill box, and an if statement would check if the lives variable was 0, when it reaches 0, the ball is deleted rendering the gameplay over and the lives counter would display "Game over" to the player.
