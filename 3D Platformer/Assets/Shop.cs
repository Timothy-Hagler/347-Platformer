using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    public GameManager gm;
    public int requiredCoins;
    public int starsRemaining;
    public AudioSource audio;
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
        if (other.tag.Equals("Player"))
        {
            if (gm.currentCoins >= requiredCoins && starsRemaining > 0)
            {
                gm.AddCoin(-requiredCoins);
                gm.AddStar(1);
                requiredCoins += 20;
                starsRemaining--;
                FindObjectOfType<AudioManager>().Play("Star");
            }
        }
    }
}
