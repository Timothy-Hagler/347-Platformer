using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBoss : MonoBehaviour
{
    public int health = 3;
    public GameObject[] platforms;
    private int index = 0;
    public PlayerController player;
    public GameObject winBox;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            winBox.SetActive(true);
            Destroy(transform.parent.gameObject);
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            health -= 1;
            Debug.Log(health);
             
            platforms[index].SetActive(false);
            if (index != 2)
            {
                platforms[index + 1].SetActive(true);
                index++;
            }
            //player.velocity.x = Random.Range(0f, 30f);
            player.velocity.y = 40f;
            //player.velocity.z = Random.Range(0f, 20f);
           // StartCoroutine("LaunchPlayer");
        }
    }
    IEnumerable LaunchPlayer()
    {
        
        player.velocity.x = 0f;
        player.velocity.y = 0f;
        player.velocity.z = 0f;
        yield return null;
        
    }
}
