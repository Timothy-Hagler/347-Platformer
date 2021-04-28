using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public PlayerController player;
    public GameObject canvas;
    

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private void OnTriggerEnter(Collider other)
    {
        player.enableInteract = true;
        if (other.tag.Equals("Player"))// && player.canInteract)
        {
            canvas.SetActive(true);
            Cursor.visible = true;
            TriggerDialogue();
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
        if (other.tag.Equals("Player"))
        {
            canvas.SetActive(false);
            Cursor.visible = false;
            FindObjectOfType<DialogueManager>().EndDialogue();
            player.canInteract = false;
        }
    }

    


}
