using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    public HealthManager healthMan;
    public Renderer rend;

    public Material cpOff;
    public Material cpOn;

    
    // Start is called before the first frame update
    void Start()
    {
        healthMan = FindObjectOfType<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckPointOn()
    {
        Checkpoint[] checkpoints = FindObjectsOfType<Checkpoint>();
        foreach(Checkpoint c in checkpoints)
        {
            c.CheckPointOff();
        }


        rend.material = cpOn;
    }

    public void CheckPointOff()
    {
        rend.material = cpOff;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            healthMan.SetSpawnPoint(transform.position);
            CheckPointOn();
        }
    }
}
