using UnityEngine.SceneManagement;
using UnityEngine;

public class StartMenu : MonoBehaviour
{

    public void StartGame() {

        Debug.Log("Let's play!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

}
