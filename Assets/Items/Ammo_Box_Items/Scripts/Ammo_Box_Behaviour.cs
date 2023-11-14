using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo_Box_Behaviour : MonoBehaviour
{


    //Somehow add a clip to the different guns based on which ammo box is picked up;
    private void OnTriggerEnter(Collider Collider)
    {
        Debug.Log("You are inside the ammo box");
        if (Collider.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Debug.Log("IT WORKED!!!");
            
        }
    }
}
