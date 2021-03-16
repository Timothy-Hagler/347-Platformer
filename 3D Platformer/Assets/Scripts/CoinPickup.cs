using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
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
        transform.Rotate(0, 90 * Time.deltaTime, 0);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<GameManager>().AddCoin(value);
            //coinSound.Play();

            FindObjectOfType<AudioManager>().Play("Coin");

            Destroy(gameObject);
        }    
    }
}
