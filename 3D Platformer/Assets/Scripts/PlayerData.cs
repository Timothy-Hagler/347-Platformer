using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public int stars;
    public int health;
    public float[] position;

    public PlayerData(GameManager gm, PlayerController player)
    {
        stars = gm.currentStars;
        health = gm.health.currentHealth;

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

    }
}
