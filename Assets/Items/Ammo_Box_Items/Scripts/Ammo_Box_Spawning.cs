using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo_Box_Spawning : MonoBehaviour
{
    public List<GameObject> Ammo_Box_Type_Prefabs;

    [HideInInspector]
    public GameObject Ammo_Box_Type;

    public int Max_Box_Spawn_Amount;
    public int Box_Spawning_Count;

    public Transform Parent_Object;
    public List<Vector3> Ammo_Box_Spawning_Points;

    [HideInInspector]
    public float Spawn_X_Position;

    [HideInInspector]
    public float Spawn_Z_Position;

    [HideInInspector]
    public List<Vector3> Ammo_Box_Already_Spawned_Points = new List<Vector3>();

    void Start()
    {
        InvokeRepeating("Spawn_Ammo", 0f, Random.Range(15, 20));
    }

    void Spawn_Ammo()
    {
        if (Box_Spawning_Count < Max_Box_Spawn_Amount && Ammo_Box_Spawning_Points != null && Ammo_Box_Spawning_Points.Count > 0)
        {
            Random_Position_And_Type();

            while (Ammo_Box_Already_Spawned_Points.Contains(new Vector3(Spawn_X_Position, 0.35f, Spawn_Z_Position)))
            {
                Random_Position_And_Type();
            }

            Ammo_Box_Already_Spawned_Points.Add(new Vector3(Spawn_X_Position, 0.35f, Spawn_Z_Position));

            GameObject New_Ammo_Box = Instantiate(Ammo_Box_Type, new Vector3(Spawn_X_Position, 0.35f, Spawn_Z_Position), Quaternion.identity);
            New_Ammo_Box.transform.parent = Parent_Object;

            Box_Spawning_Count++;
        }
    }

    public void Random_Position_And_Type()
    {
        int Random_List_Position = Random.Range(0, Ammo_Box_Spawning_Points.Count);
        int Random_Ammo_Box_Type = Random.Range(0, Ammo_Box_Type_Prefabs.Count);

        Vector3 Random_Spawning_Point = Ammo_Box_Spawning_Points[Random_List_Position];
        Ammo_Box_Type = Ammo_Box_Type_Prefabs[Random_Ammo_Box_Type];

        Spawn_X_Position = Random_Spawning_Point.x;
        Spawn_Z_Position = Random_Spawning_Point.z;
    }

}
