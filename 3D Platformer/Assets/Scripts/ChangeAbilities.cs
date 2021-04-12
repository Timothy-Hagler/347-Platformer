using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAbilities : MonoBehaviour
{

    public PlayerController player;
    public bool menuIsOpen = false;
    public GameObject menuUI;


    public void ShowMenu()
    {
        menuUI.SetActive(true);
        Cursor.visible = true;
        menuIsOpen = true;
    }

    public void HideMenu()
    {
        menuUI.SetActive(false);
        Cursor.visible = false;
        menuIsOpen = false;
    }
    public void UseSpeed()
    {
        player.SetAbility("speed");
    }
    public void UseDoubleJump()
    {
        player.SetAbility("double jump");
    }
    public void UseWallClimb()
    {
        player.SetAbility("wall climb");
    }
    public void UseGlide()
    {
        player.SetAbility("glide");
    }
}
