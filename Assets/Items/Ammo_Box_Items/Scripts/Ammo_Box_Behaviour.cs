using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo_Box_Behaviour : MonoBehaviour
{
    //This script is not detecing the player for some reason???
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
