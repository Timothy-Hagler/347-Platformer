using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public GameObject dialoguePanel;
    public Text npcNameText;
    public Text dialogueText;

    public Animator animator;
    public PlayerController player;

    

    private Queue<string> sentences;
    private int convoIndex;

    public static bool isInDialogue;



    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        player = FindObjectOfType<PlayerController>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        isInDialogue = true;
        player.moveSpeed = 0f;
        animator.SetBool("isOpen", true);

        npcNameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

       // dialogueText.text = sentence;
    }

    public void EndDialogue()
    {
        Debug.Log("End of conversation");
        animator.SetBool("isOpen", false);
        isInDialogue = false;
        player.moveSpeed = player.t_moveSpeed;
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }
}
