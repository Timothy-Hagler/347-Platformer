using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowmanCreator : MonoBehaviour
{
    public GameObject[] snowball;
    public Transform[] placement;
    public int index;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Snowball"))
        {
           // snowball[index].transform.position = placement[index].position;
            snowball[index].SetActive(true);
            Destroy(other.gameObject);
            index++;
        }
    }
}
