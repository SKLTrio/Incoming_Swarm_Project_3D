using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Spawning : MonoBehaviour
{
    public List<GameObject> Zombie_Type_Prefabs;

    public Transform Parent_Object;

    public List<Vector3> Zombie_Spawning_Points;

    [HideInInspector]
    public float Spawn_X_Position;

    [HideInInspector]
    public float Spawn_Z_Position;

    [HideInInspector]
    public GameObject Zombie_Type;

    public int Max_Zombie_Count;
    public int Zombie_Count;
    public int Zombie_Group_Count;

    void Start()
    {
        InvokeRepeating("Spawn_Zombies", 0f, Random.Range(15, 31));
    }

    void Spawn_Zombies()
    {
        if (Zombie_Count < Max_Zombie_Count && Zombie_Spawning_Points != null && Zombie_Spawning_Points.Count > 0)
        {
            Random_Position_And_Type();

            int Zombie_Group_Size = Mathf.Clamp(Zombie_Group_Count, 1, 7);

            for (int i = 0; i < Zombie_Group_Size; i++)
            {
                Debug.Log("This new position is: " + Spawn_X_Position + ", 0, " + Spawn_Z_Position);
                GameObject New_Zombie = Instantiate(Zombie_Type, new Vector3(Spawn_X_Position, 2.23f, Spawn_Z_Position), Quaternion.identity);
                New_Zombie.transform.parent = Parent_Object;
                Zombie_Count += 1;
            }
        }
    }

    public void Random_Position_And_Type()
    {
        Zombie_Group_Count = Random.Range(1, 8);
        int Random_List_Position = Random.Range(0, Zombie_Spawning_Points.Count);
        int Random_Zombie_Type = Random.Range(0, Zombie_Type_Prefabs.Count);

        Vector3 Random_Spawning_Point = Zombie_Spawning_Points[Random_List_Position];
        Zombie_Type = Zombie_Type_Prefabs[Random_Zombie_Type];

        Spawn_X_Position = Random_Spawning_Point.x;
        Spawn_Z_Position = Random_Spawning_Point.z;
    }
}
