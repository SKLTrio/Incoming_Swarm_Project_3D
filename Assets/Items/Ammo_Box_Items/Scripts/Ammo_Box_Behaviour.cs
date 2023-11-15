using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo_Box_Behaviour : MonoBehaviour
{
    Weapon_Reload_Script Weapon_Reload_Script;

    private void Start()
    {
        Weapon_Reload_Script = FindObjectOfType<Weapon_Reload_Script>();
    }

    
    private void OnTriggerEnter(Collider Collider)
    {
        Debug.Log("You are inside the ammo box");

        if (Collider.gameObject.CompareTag("Player"))
        {
            Weapon_Reload_Script[] Reload_Scripts = FindObjectsOfType<Weapon_Reload_Script>();

            foreach (Weapon_Reload_Script Reload_Script in Reload_Scripts)
            {
                Destroy(gameObject);
                Weapon_Reload_Script.Current_Clip_Amount += 1;
                Weapon_Reload_Script.Gun_Clip_Ammo_Text.color = Color.white;
                Weapon_Reload_Script.Gun_Clip_Ammo_Text.text = "x " + Weapon_Reload_Script.Current_Clip_Amount.ToString();
                Debug.Log(Weapon_Reload_Script.Current_Clip_Amount);
            }
        }
    }
}
