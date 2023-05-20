using UnityEngine;

public class FinalPointTrigger : MonoBehaviour
{

    public GameManager manager;

    public void OnTriggerEnter(Collider other) {

        manager.WinLevel();

    }

}
