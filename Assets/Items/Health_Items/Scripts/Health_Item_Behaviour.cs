using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Item_Behaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider Collider)
    {
        Debug.Log("You are inside the health item");

        if (Collider.gameObject.CompareTag("Player"))
        {
            GameObject Player_Object = Collider.gameObject;

            Player_Health_Item_Store_Script Health_Item_Store_Script = Player_Object.GetComponentInChildren<Player_Health_Item_Store_Script>();

            if (Health_Item_Store_Script == null)
            {
                Debug.Log("Health_Item_Store_Script is null");
                return;
            }

            Health_Item_Store_Script.Health_Item_Count++;

            Destroy(gameObject);
        }
    }
}
