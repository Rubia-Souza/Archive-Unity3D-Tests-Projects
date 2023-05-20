using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public float cameraMoveSpeed = 120.0f;
    public float clampAngle = 80.0f;
    public float inputSensitivite = 150.0f;
    public float mouseX, mouseY, finalMouseX, finalMouseZ;
    public float smoothX, smoothY;

    public Transform target;
    public Transform cameraObject;
    public Transform cameraFollowObject;

    public Vector3 followPosition;
    public Vector3 playerDistance;

    private float rotationY = 0.0f, rotationX = 0.0f;

    private void Start() {

        Vector3 rotation = transform.localRotation.eulerAngles;

        rotationY = rotation.y;
        rotationX = rotation.x;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    private void Update() {

        float inputX = Input.GetAxis("RightStickHorizontal");
        float inputZ = Input.GetAxis("RightStickVertical");

        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        float teste =  Input.GetAxis("Horizontal");

        finalMouseX = inputX + mouseX;
        finalMouseZ = inputZ + mouseY;

        rotationY += finalMouseX * inputSensitivite * Time.deltaTime;
        rotationX += finalMouseZ * inputSensitivite * Time.deltaTime;

        rotationX = Mathf.Clamp(rotationX, -clampAngle, +clampAngle);

        if (Input.GetKey(KeyCode.LeftControl)) {

            transform.rotation = Quaternion.Euler(rotationX, rotationY, 0.0f);

        }
        else {

            transform.rotation = Quaternion.Euler(rotationX, rotationY, 0.0f);
            target.transform.rotation = Quaternion.Euler(0, rotationY, 0);

        }

    }

    // Executado apos o Update
    private void LateUpdate() {

        CameraUpdater();

    }

    private void CameraUpdater() {

        float step = cameraMoveSpeed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, cameraFollowObject.position, step);

    }

}
