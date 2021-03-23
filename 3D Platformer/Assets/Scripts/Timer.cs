using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public float totalTime;
    public float timeRemaining;
    public string methodToCall;
    public string typeOfTimer;

    public List<GameObject> items;
    //public Transform[] itemTransforms;

    public GameObject tOther;
    public GameObject star;

    public int count;

    // Start is called before the first frame update
    void Start()
    {
        count = items.Count;
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
            gameObject.SetActive(false);
        }
    }

    private void RunTimer()
    {
        Debug.Log(items.Count);
        timeRemaining -= Time.deltaTime / 2.5f;
        if (typeOfTimer == "blocks")
            SpawnStar();
        if (timeRemaining <= 0 && count > 0)
        {
            DespawnObjects();
            // gameObject.SetActive(true);
        }
        else if (count == 0)
            SpawnStar();
        else
            Invoke("RunTimer", 0f);
    }


    private void SpawnStar()
    {
        if (star != null)
            star.SetActive(true);
    }

    private void SpawnCoins()
    {
        
        Debug.Log("Spawn Coins");
        foreach (GameObject obj in items)
        {
            obj.SetActive(true);
        }
    }

    private void DespawnObjects()
    {
        Debug.Log("Despawn Objects");
        if (items != null)
        {
            gameObject.SetActive(true);
            count = items.Count;
            foreach (GameObject obj in items)
            {
                obj.SetActive(false);
            }
        }
    }

}
