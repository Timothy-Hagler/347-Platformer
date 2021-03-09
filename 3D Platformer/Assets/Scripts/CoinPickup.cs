using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{

    public int value;
    public AudioSource coinSound;

    // Start is called before the first frame update
    void Start()
    {
        coinSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<GameManager>().AddCoin(value);
            coinSound.Play();
            

            Destroy(gameObject);
        }    
    }
}
