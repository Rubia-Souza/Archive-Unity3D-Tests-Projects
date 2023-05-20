using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private bool gameHasEnded = false;

    public float restartDelay = 2f;
    public GameObject levelCompletUI;

    public void CompleteLevel() {

        levelCompletUI.SetActive(true);

    }

    public void GameOver() {

        if (!gameHasEnded) {

            gameHasEnded = true;
            Invoke("Restart", restartDelay); 

        }

    }

    public void WinLevel() {

        CompleteLevel();

    }

    private void Restart() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

}
