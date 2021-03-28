using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public int currentCoins;
    public int currentStars;
    public int totalStars;

    public Text coinText;
    public Text starText;
    public Text healthText;

    public HealthManager health;

    //Pyramid Vars
    public int activeBeams;
    public GameObject lava;
    public GameObject water;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void AddCoin(int coinToAdd)
    {
        currentCoins += coinToAdd;
        coinText.text = "Coins: " + currentCoins;
    }

    public void AddStar(int starToAdd)
    {
        currentStars += starToAdd;
        totalStars += starToAdd;
        starText.text = "Stars: " + currentStars;
    }

    public void removeStar(int starToRemove)
    {
        currentStars -= starToRemove;
        starText.text = "Stars: " + currentStars;
    }

    public void changeHealth()
    {
        healthText.text = "Health " + health.currentHealth;
    }

    public void UpdateBeams()
    {
        activeBeams++;

        if (activeBeams == 5)
        {
            lava.SetActive(false);
            water.SetActive(true);
        }
    }
}
