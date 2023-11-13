using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class Weapon_Reload_Script : MonoBehaviour
{
    //The amount of ammo clips the player has.
    public int Weapon_Clips_Available;
    //The amount of bullets in each clip.
    public int Bullets_Per_Ammo_Clip;

    //The current amount of clips the player has;
    public int Current_Clip_Amount;
    //The current ammo count.
    public int Current_Bullet_Amount_In_Clip;

    private void Start()
    {
        Current_Clip_Amount = Weapon_Clips_Available;
        Current_Bullet_Amount_In_Clip = Bullets_Per_Ammo_Clip;
    }

    public void On_Reload(InputAction.CallbackContext Context)
    {
        if (Context.performed)
        {
            Reload_Gun();
        }
    }

    public void Reload_Gun()
    {
        if (Current_Clip_Amount > 0 && Current_Bullet_Amount_In_Clip < Bullets_Per_Ammo_Clip)
        {

            Current_Clip_Amount -= 1;
            Current_Bullet_Amount_In_Clip = Bullets_Per_Ammo_Clip;

            Debug.Log("Reloaded. Clips: " + Current_Clip_Amount + " Ammo in clip: " + Current_Bullet_Amount_In_Clip);

        }

        else
        {
            Debug.Log("No need to reload or your out of clips.");
        }
    }
}
