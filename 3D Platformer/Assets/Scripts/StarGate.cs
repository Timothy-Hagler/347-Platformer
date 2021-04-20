using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StarGate : MonoBehaviour
{

    public int requiredStars;
    public PlayerController controller;
    public GameManager gm;
    public string ability;
    public GameObject jailCell;
    public GameObject canvas;
    public TMP_Text requiredStarsText;
    public RevealWorld reveal;
    public bool canReveal = false;

    // Start is called before the first frame update
    void Start()
    {
        if (canReveal)
            reveal = GetComponent<RevealWorld>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            DialogueManager.isInDialogue = true;
            canvas.SetActive(true);
            Cursor.visible = true;
            requiredStarsText.text = "Free animal (" + requiredStars + " stars)";
        }
    }

    public void FreeAnimal()
    {
        if (gm.currentStars >= requiredStars)
        {
            controller.AddAbility(ability);
            gm.removeStar(requiredStars);
            Destroy(jailCell);
            if (canReveal)
                reveal.Reveal();
            LeaveAnimal();
            Destroy(gameObject);
        }
    }

    public void LeaveAnimal()
    {
        DialogueManager.isInDialogue = false;
        canvas.SetActive(false);
        Cursor.visible = false;
    }
}
