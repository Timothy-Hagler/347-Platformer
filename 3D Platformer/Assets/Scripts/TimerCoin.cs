using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerCoin : MonoBehaviour
{

    public Timer timer;
    public AudioSource coinSound;
    // Start is called before the first frame update
    void Start()
    {
        coinSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // timer.items.RemoveAt(timer.items.Count - 1);
            timer.count--;
            gameObject.SetActive(false);
            FindObjectOfType<AudioManager>().Play("Coin");

            // Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 90 * Time.deltaTime, 0);
    }
}
