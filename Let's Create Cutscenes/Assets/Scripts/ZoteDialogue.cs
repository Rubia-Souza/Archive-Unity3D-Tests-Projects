using UnityEngine;

public class ZoteDialogue : MonoBehaviour {

    public Dialogue dialogue;

    public void DialogueTrigger() {

        DialogueManager manager = GetComponent<DialogueManager>();

        // Inicia o dialogo
        manager.StartConversation(dialogue);

    }

}
