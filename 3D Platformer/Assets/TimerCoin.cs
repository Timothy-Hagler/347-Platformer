using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerCoin : MonoBehaviour
{

    public Timer timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // timer.items.RemoveAt(timer.items.Count - 1);
            timer.count--;
            gameObject.SetActive(false);
           // Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
