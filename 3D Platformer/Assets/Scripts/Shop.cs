using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    public GameManager gm;
    public int requiredCoins;
    public int starsRemaining;
    public AudioSource sound;
    public PlayerController player;
    public CameraController mainCam;

    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = FindObjectOfType<CameraController>();
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            DialogueManager.isInDialogue = true;
            canvas.SetActive(true);
            Cursor.visible = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            canvas.SetActive(false);
            Cursor.visible = false;
        }
    }

    public void BuyStar()
    {
        if (GameManager.currentCoins >= requiredCoins && starsRemaining > 0)
        {
            
            gm.AddCoin(-requiredCoins);
            gm.AddStar(1);
            // requiredCoins += 20;
            starsRemaining--;
            FindObjectOfType<AudioManager>().Play("Star");
            
        }

        if (starsRemaining <= 0)
        {
            LeaveShop();
            gameObject.SetActive(false);
        }
    }

    public void LeaveShop()
    {
        DialogueManager.isInDialogue = false;
        canvas.SetActive(false); 
        Cursor.visible = false;
    }
}
