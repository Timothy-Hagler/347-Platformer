using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarPickup : MonoBehaviour
{

    public int value;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            string playing = AudioManager.currPlaying;
            Debug.Log(playing);
            FindObjectOfType<GameManager>().AddStar(value);
            FindObjectOfType<AudioManager>().Pause(playing);
            FindObjectOfType<AudioManager>().Play("Star");
            //FindObjectOfType<AudioManager>().UnPause(playing);

            Destroy(gameObject);
        }
    }
}
