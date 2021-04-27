using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandOnEnemy : MonoBehaviour
{
    public GameManager gm;
    public PlayerController player;
    public AudioManager coinSound;
    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        player = FindObjectOfType<PlayerController>();
        coinSound = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            foreach (Transform child in transform)
                child.gameObject.SetActive(false);
            gm.AddCoin(1);
            coinSound.Play("Coin");
            player.velocity.y = 10f;
            
            Destroy(transform.parent.gameObject);
        }
    }
}
