using UnityEngine;

public class PlayerColision : MonoBehaviour
{

    public PlayerMovement playerMoveScript;

    public void OnCollisionEnter(Collision collisionInfo) {

        if (collisionInfo.collider.tag == "Obstaculo") {

            playerMoveScript.rbPlayer.AddForce(0, 0, -(playerMoveScript.forwardForce / 2 + 120));
            playerMoveScript.enabled = false;

            FindObjectOfType<GameManager>().GameOver();

        }

    }

}
