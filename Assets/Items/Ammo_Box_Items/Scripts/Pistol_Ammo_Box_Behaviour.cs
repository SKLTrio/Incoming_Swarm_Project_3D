using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol_Ammo_Box_Behaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider Collider)
    {
        Debug.Log("You are inside the ammo box");

        if (Collider.gameObject.CompareTag("Player"))
        {
            GameObject Player_Object = Collider.gameObject;

            Pistol_Reload_Script Pistol_Reload_Script = Player_Object.GetComponentInChildren<Pistol_Reload_Script>();

            GameObject Ammo_Spawner_Object = GameObject.FindGameObjectWithTag("Ammo_Box_Spawner");

            Ammo_Box_Spawning Ammo_Box_Spawning_Script = Ammo_Spawner_Object.GetComponentInChildren<Ammo_Box_Spawning>();

            if (Pistol_Reload_Script == null)
            {
                Debug.Log("Pistol Reload Script is null");
                return;
            }

            else
            {
                Destroy(gameObject);
                Ammo_Box_Spawning_Script.Box_Spawning_Count--;
                Pistol_Reload_Script.Current_Clip_Amount += 1;
                Pistol_Reload_Script.Gun_Clip_Ammo_Text.color = Color.white;
                Pistol_Reload_Script.Gun_Clip_Ammo_Text.text = "x " + Pistol_Reload_Script.Current_Clip_Amount.ToString();
                Debug.Log(Pistol_Reload_Script.Current_Clip_Amount);
            }
        }
    }
}
