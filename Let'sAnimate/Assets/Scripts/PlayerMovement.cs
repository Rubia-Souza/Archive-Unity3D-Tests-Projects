using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speedX, speedZ;
    public float runningSpeedX, runningSpeedZ;
    public Rigidbody playerBody;

    private float inputHorizontal, inputVertical;
    private bool isRunning;

    void Start()
    {

        playerBody = GetComponent<Rigidbody>();

    }

    void Update()
    {

        CharacterMovement();

    }

    void CharacterMovement() {

        float moveX, moveZ;

        inputHorizontal = Input.GetAxis("Horizontal");
        inputVertical = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift)) {
            isRunning = true;
        }
        else {
            isRunning = false;
        }


        if (!isRunning) {
            moveX = inputHorizontal * speedX * Time.deltaTime;
            moveZ = inputVertical * speedZ * Time.deltaTime;
        }
        else {
            moveX = inputHorizontal * runningSpeedX * Time.deltaTime;
            moveZ = inputVertical * runningSpeedZ * Time.deltaTime;
        }


        if (moveZ <= 0)
            moveX = 0;

        //playerBody.velocity = new Vector3(moveX, 0f, moveZ);
        playerBody.transform.Translate(new Vector3(moveX, 0f, moveZ), Space.Self);

    }
}
