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
        InvokeRepeating("Spawn_Zombies", 0f, Random.Range(10, 20));

        //City Zombies:

        GameObject New_Zombie = Instantiate(Zombie_Type_Prefabs[0], new Vector3(-391, 2.23f, 57), Quaternion.identity);
        New_Zombie.transform.parent = Parent_Object;

        GameObject New_Zombie_2 = Instantiate(Zombie_Type_Prefabs[0], new Vector3(-392, 2.23f, 57), Quaternion.identity);
        New_Zombie_2.transform.parent = Parent_Object;

        GameObject New_Zombie_3 = Instantiate(Zombie_Type_Prefabs[0], new Vector3(-390, 2.23f, 57), Quaternion.identity);
        New_Zombie_3.transform.parent = Parent_Object;

        GameObject New_Zombie_4 = Instantiate(Zombie_Type_Prefabs[1], new Vector3(-460, 2.23f, 120), Quaternion.identity);
        New_Zombie_4.transform.parent = Parent_Object;

        GameObject New_Zombie_5 = Instantiate(Zombie_Type_Prefabs[1], new Vector3(-461, 2.23f, 120), Quaternion.identity);
        New_Zombie_5.transform.parent = Parent_Object;

        GameObject New_Zombie_6 = Instantiate(Zombie_Type_Prefabs[1], new Vector3(-459, 2.23f, 120), Quaternion.identity);
        New_Zombie_6.transform.parent = Parent_Object;

        GameObject New_Zombie_7 = Instantiate(Zombie_Type_Prefabs[1], new Vector3(-460, 2.23f, 121), Quaternion.identity);
        New_Zombie_7.transform.parent = Parent_Object;

        GameObject New_Zombie_8 = Instantiate(Zombie_Type_Prefabs[2], new Vector3(-344, 2.23f, 140), Quaternion.identity);
        New_Zombie_8.transform.parent = Parent_Object;

        GameObject New_Zombie_9 = Instantiate(Zombie_Type_Prefabs[2], new Vector3(-344, 2.23f, 141), Quaternion.identity);
        New_Zombie_9.transform.parent = Parent_Object;

        GameObject New_Zombie_10 = Instantiate(Zombie_Type_Prefabs[2], new Vector3(-344, 2.23f, 139), Quaternion.identity);
        New_Zombie_10.transform.parent = Parent_Object;

        GameObject New_Zombie_11 = Instantiate(Zombie_Type_Prefabs[2], new Vector3(-345, 2.23f, 140), Quaternion.identity);
        New_Zombie_11.transform.parent = Parent_Object;

        GameObject New_Zombie_12 = Instantiate(Zombie_Type_Prefabs[2], new Vector3(-343, 2.23f, 140), Quaternion.identity);
        New_Zombie_12.transform.parent = Parent_Object;

        //Farm Zombies:

        GameObject New_Zombie_13 = Instantiate(Zombie_Type_Prefabs[0], new Vector3(40, 2.23f, 16), Quaternion.identity);
        New_Zombie_13.transform.parent = Parent_Object;

        GameObject New_Zombie_14 = Instantiate(Zombie_Type_Prefabs[2], new Vector3(41, 2.23f, 16), Quaternion.identity);
        New_Zombie_14.transform.parent = Parent_Object;

        GameObject New_Zombie_15 = Instantiate(Zombie_Type_Prefabs[1], new Vector3(39, 2.23f, 16), Quaternion.identity);
        New_Zombie_15.transform.parent = Parent_Object;

        GameObject New_Zombie_16 = Instantiate(Zombie_Type_Prefabs[1], new Vector3(40, 2.23f, 17), Quaternion.identity);
        New_Zombie_16.transform.parent = Parent_Object;

        GameObject New_Zombie_17 = Instantiate(Zombie_Type_Prefabs[0], new Vector3(40, 2.23f, 15), Quaternion.identity);
        New_Zombie_17.transform.parent = Parent_Object;

    }

    void Spawn_Zombies()
    {
        if (Zombie_Count < Max_Zombie_Count && Zombie_Spawning_Points != null && Zombie_Spawning_Points.Count > 0)
        {
            Random_Position_And_Type();

            int Zombie_Group_Size = Mathf.Clamp(Zombie_Group_Count, 3, 7);

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
        Zombie_Group_Count = Random.Range(3, 8);
        int Random_List_Position = Random.Range(0, Zombie_Spawning_Points.Count);
        int Random_Zombie_Type = Random.Range(0, Zombie_Type_Prefabs.Count);

        Vector3 Random_Spawning_Point = Zombie_Spawning_Points[Random_List_Position];
        Zombie_Type = Zombie_Type_Prefabs[Random_Zombie_Type];

        Spawn_X_Position = Random_Spawning_Point.x;
        Spawn_Z_Position = Random_Spawning_Point.z;
    }
}
