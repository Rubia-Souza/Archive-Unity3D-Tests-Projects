using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Transform playerPosition;
    public Text scoreText;

    void Update () {
        scoreText.text = playerPosition.position.z.ToString("0");
    }
}
