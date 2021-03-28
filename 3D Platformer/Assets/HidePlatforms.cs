using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidePlatforms : MonoBehaviour
{

    public Renderer[] platforms;
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
            int j = 0;
            foreach (Renderer i in platforms)
            {
                
                platforms[j].enabled = true;
                j++;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            int j = 0;
            foreach (Renderer i in platforms)
            {

                platforms[j].enabled = false;
                j++;
            }
        }
    }
}
