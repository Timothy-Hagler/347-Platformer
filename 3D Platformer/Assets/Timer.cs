using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public float totalTime;
    public float timeRemaining;
    public string methodToCall;

    public GameObject[] items;
    public Transform[] itemTransforms;

    public GameObject tOther;

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
            //tOther = other.gameObject;
            timeRemaining = totalTime;
            
            SpawnCoins();
            RunTimer();
           // gameObject.SetActive(false);
        }
    }

    private void RunTimer()
    {
        timeRemaining -= Time.deltaTime;
        if (timeRemaining <= 0)
        {
            DespawnCoins();
            // gameObject.SetActive(true);
        }
        else
            Invoke("RunTimer", 0f);
    }

    private void SpawnCoins()
    {
        
        Debug.Log("Spawn Coins");
        foreach (GameObject obj in items)
        {
            obj.SetActive(true);
        }
    }

    private void DespawnCoins()
    {
        Debug.Log("Despawn Coins");
        foreach (GameObject obj in items)
        {
            obj.SetActive(false);    
        }
    }

}
