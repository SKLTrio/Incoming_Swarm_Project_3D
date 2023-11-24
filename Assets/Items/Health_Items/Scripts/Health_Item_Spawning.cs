using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Item_Spawning : MonoBehaviour
{
    public List<GameObject> Health_Item_Type_Prefabs;

    [HideInInspector]
    public GameObject Health_Item_Type;

    public int Max_Item_Spawn_Amount;
    public int Health_Item_Spawning_Count;

    public Transform Parent_Object;
    public List<Vector3> Health_Item_Spawning_Points;

    [HideInInspector]
    public float Spawn_X_Position;

    [HideInInspector]
    public float Spawn_Z_Position;

    [HideInInspector]
    public List<Vector3> Health_Item_Already_Spawned_Points = new List<Vector3>();

    void Start()
    {
        InvokeRepeating("Spawn_Health_Item", 0f, Random.Range(20, 30));
    }

    void Spawn_Health_Item()
    {
        if (Health_Item_Spawning_Count < Max_Item_Spawn_Amount && Health_Item_Spawning_Points != null && Health_Item_Spawning_Points.Count > 0)
        {
            Random_Position_And_Type();

            while (Health_Item_Already_Spawned_Points.Contains(new Vector3(Spawn_X_Position, 0.35f, Spawn_Z_Position)))
            {
                Random_Position_And_Type();
            }

            Health_Item_Already_Spawned_Points.Add(new Vector3(Spawn_X_Position, 0.35f, Spawn_Z_Position));

            GameObject New_Ammo_Box = Instantiate(Health_Item_Type, new Vector3(Spawn_X_Position, 0.35f, Spawn_Z_Position), Quaternion.identity);
            New_Ammo_Box.transform.parent = Parent_Object;

            Health_Item_Spawning_Count++;
        }
    }

    public void Random_Position_And_Type()
    {
        int Random_List_Position = Random.Range(0, Health_Item_Spawning_Points.Count);
        int Random_Health_Item_Type = Random.Range(0, Health_Item_Type_Prefabs.Count);

        Vector3 Random_Spawning_Point = Health_Item_Spawning_Points[Random_List_Position];
        Health_Item_Type = Health_Item_Type_Prefabs[Random_Health_Item_Type];

        Spawn_X_Position = Random_Spawning_Point.x;
        Spawn_Z_Position = Random_Spawning_Point.z;
    }
}
