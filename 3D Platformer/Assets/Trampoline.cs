using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{

    public PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Trampoline");
            Vector3 jump = new Vector3(0f, 50f, 0f);
            player.controller.SimpleMove(new Vector3(0f,100f,0f));
            player.controller.Move(new Vector3 (0f, Mathf.Lerp(jump.y, player.transform.position.y, 0f), 0f));
        }
    }
}
