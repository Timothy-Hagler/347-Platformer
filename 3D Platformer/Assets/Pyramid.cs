using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pyramid : MonoBehaviour
{

    public GameObject beam;
    public GameObject star;
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
       

        if(other.tag.Equals("Player"))
        {
            beam.SetActive(true);
            star.SetActive(true);
            gameObject.SetActive(false);
        }

    }
}
