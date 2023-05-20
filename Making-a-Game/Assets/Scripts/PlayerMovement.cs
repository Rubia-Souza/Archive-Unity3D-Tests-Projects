using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody rbPlayer;
    public float forwardForce = 800f;
    public float sidewaysForce = 10f;
    public bool moveLeft, moveRigth, moveForward, moveBackward;

    void Update() {
     
        if ( Input.GetKeyDown(KeyCode.D) ) {
            moveRigth = true;
        }
        else if ( Input.GetKeyUp(KeyCode.D) ) {
            moveRigth = false;
        }

        if ( Input.GetKeyDown(KeyCode.A) ) {
            moveLeft = true;
        } 
        else if ( Input.GetKeyUp(KeyCode.A) ) {
            moveLeft = false;
        }

        if ( Input.GetKeyDown(KeyCode.W) ) {
            moveForward = true;
        } 
        else if ( Input.GetKeyUp(KeyCode.W) ) {
            moveForward = false;
        }

        if ( Input.GetKeyDown(KeyCode.S) ) {
            moveBackward = true;
        } 
        else if (Input.GetKeyUp(KeyCode.S)) {
            moveBackward = false;
        }

    }

    void FixedUpdate() {
        
        if (moveRigth)
            rbPlayer.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

        if (moveLeft) 
            rbPlayer.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

        if (moveForward) 
            rbPlayer.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (moveBackward)
            rbPlayer.AddForce(0, 0, -forwardForce * Time.deltaTime);

        if (rbPlayer.position.y < 0) 
            FindObjectOfType<GameManager>().GameOver();

    }
}
