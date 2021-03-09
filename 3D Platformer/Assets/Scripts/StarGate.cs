using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGate : MonoBehaviour
{

    public int requiredStars;
    public PlayerController controller;
    public GameManager gm;
    public string ability;

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
        if (other.gameObject.tag == "Player")
        {
            if (gm.currentStars >= requiredStars)
            {
                controller.AddAbility(ability);
                gm.removeStar(requiredStars);
                Destroy(gameObject);
            } 
        }
    }
}
