using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glide : MonoBehaviour
{
    public bool glideAvailable;
    public bool glideActive;
    public float t_Grav;
    public PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
      //  t_Grav = player.gravity;
    }

    // Update is called once per frame
    void Update()
    {
       /* if (glideActive && player.jumpCount == 2)// && Input.GetKeyDown(KeyCode.Space))
        {
            player.gravity = -10f;
        }
        else if (glideActive)
            player.gravity = t_Grav;*/
    }

    public void SetGlideAvailable(bool value)
    {
        glideAvailable = value;
    }

}
