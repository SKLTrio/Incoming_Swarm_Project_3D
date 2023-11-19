using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP5_Ammo_Box_Behaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider Collider)
    {
        Debug.Log("You are inside the ammo box");

        if (Collider.gameObject.CompareTag("Player"))
        {
            GameObject Player_Object = Collider.gameObject;

            MP5_Reload_Script MP5_Reload_Script = Player_Object.GetComponentInChildren<MP5_Reload_Script>();

            GameObject Ammo_Spawner_Object = GameObject.FindGameObjectWithTag("Ammo_Box_Spawner");

            Ammo_Box_Spawning Ammo_Box_Spawning_Script = Ammo_Spawner_Object.GetComponentInChildren<Ammo_Box_Spawning>();

            if (MP5_Reload_Script == null)
            {
                Debug.Log("Pistol Reload Script is null");
                return;
            }

            else
            {
                Destroy(gameObject);
                Ammo_Box_Spawning_Script.Box_Spawning_Count--;
                MP5_Reload_Script.Current_Clip_Amount += 1;
                MP5_Reload_Script.Gun_Clip_Ammo_Text.color = Color.white;
                MP5_Reload_Script.Gun_Clip_Ammo_Text.text = "x " + MP5_Reload_Script.Current_Clip_Amount.ToString();
                Debug.Log(MP5_Reload_Script.Current_Clip_Amount);
            }
        }
    }
}
