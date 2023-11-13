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
        StartCoroutine(Spawn_Zombies());
    }

    IEnumerator Spawn_Zombies()
    {
        while (Zombie_Count < Max_Zombie_Count) 
        {
            if (Zombie_Spawning_Points != null && Zombie_Spawning_Points.Count > 0)
            {
                Random_Position_And_Type();

                if (Zombie_Group_Count == 1 || Zombie_Group_Count == 10)
                {
                    Debug.Log("This position is: " + Spawn_X_Position + ", 0, " + Spawn_Z_Position);
                    GameObject New_Zombie = Instantiate(Zombie_Type, new Vector3(Spawn_X_Position, 2.23f, Spawn_Z_Position), Quaternion.identity);
                    
                    New_Zombie.transform.parent = Parent_Object;
                    
                    Zombie_Count += 1;
                }

                else if (Zombie_Group_Count == 2)
                {
                    Debug.Log("This position is: " + Spawn_X_Position + ", 0, " + Spawn_Z_Position);
                    GameObject New_Zombie = Instantiate(Zombie_Type, new Vector3(Spawn_X_Position, 2.23f, Spawn_Z_Position), Quaternion.identity);
                    GameObject New_Zombie_2 = Instantiate(Zombie_Type, new Vector3(Spawn_X_Position + 1, 2.23f, Spawn_Z_Position), Quaternion.identity);

                    New_Zombie.transform.parent = Parent_Object;
                    New_Zombie_2.transform.parent = Parent_Object;

                    Zombie_Count += 2;
                }

                else if (Zombie_Group_Count == 3)
                {
                    Debug.Log("This position is: " + Spawn_X_Position + ", 0, " + Spawn_Z_Position);
                    GameObject New_Zombie = Instantiate(Zombie_Type, new Vector3(Spawn_X_Position, 2.23f, Spawn_Z_Position), Quaternion.identity);
                    GameObject New_Zombie_2 = Instantiate(Zombie_Type, new Vector3(Spawn_X_Position + 1, 2.23f, Spawn_Z_Position), Quaternion.identity);
                    GameObject New_Zombie_3 = Instantiate(Zombie_Type, new Vector3(Spawn_X_Position - 1, 2.23f, Spawn_Z_Position), Quaternion.identity);

                    New_Zombie.transform.parent = Parent_Object;
                    New_Zombie_2.transform.parent = Parent_Object;
                    New_Zombie_3.transform.parent = Parent_Object;

                    Zombie_Count += 3;
                }

                else if (Zombie_Group_Count == 4)
                {
                    Debug.Log("This position is: " + Spawn_X_Position + ", 0, " + Spawn_Z_Position);
                    GameObject New_Zombie = Instantiate(Zombie_Type, new Vector3(Spawn_X_Position, 2.23f, Spawn_Z_Position), Quaternion.identity);
                    GameObject New_Zombie_2 = Instantiate(Zombie_Type, new Vector3(Spawn_X_Position + 1, 2.23f, Spawn_Z_Position), Quaternion.identity);
                    GameObject New_Zombie_3 = Instantiate(Zombie_Type, new Vector3(Spawn_X_Position - 1, 2.23f, Spawn_Z_Position), Quaternion.identity);
                    GameObject New_Zombie_4 = Instantiate(Zombie_Type, new Vector3(Spawn_X_Position, 2.23f, Spawn_Z_Position + 1), Quaternion.identity);

                    New_Zombie.transform.parent = Parent_Object;
                    New_Zombie_2.transform.parent = Parent_Object;
                    New_Zombie_3.transform.parent = Parent_Object;
                    New_Zombie_4.transform.parent = Parent_Object;

                    Zombie_Count += 4;
                }

                else if (Zombie_Group_Count == 5)
                {
                    Debug.Log("This position is: " + Spawn_X_Position + ", 0, " + Spawn_Z_Position);
                    GameObject New_Zombie = Instantiate(Zombie_Type, new Vector3(Spawn_X_Position, 2.23f, Spawn_Z_Position), Quaternion.identity);
                    GameObject New_Zombie_2 = Instantiate(Zombie_Type, new Vector3(Spawn_X_Position + 1, 2.23f, Spawn_Z_Position), Quaternion.identity);
                    GameObject New_Zombie_3 = Instantiate(Zombie_Type, new Vector3(Spawn_X_Position - 1, 2.23f, Spawn_Z_Position), Quaternion.identity);
                    GameObject New_Zombie_4 = Instantiate(Zombie_Type, new Vector3(Spawn_X_Position, 2.23f, Spawn_Z_Position + 1), Quaternion.identity);
                    GameObject New_Zombie_5 = Instantiate(Zombie_Type, new Vector3(Spawn_X_Position, 2.23f, Spawn_Z_Position - 1), Quaternion.identity);

                    New_Zombie.transform.parent = Parent_Object;
                    New_Zombie_2.transform.parent = Parent_Object;
                    New_Zombie_3.transform.parent = Parent_Object;
                    New_Zombie_4.transform.parent = Parent_Object;
                    New_Zombie_5.transform.parent = Parent_Object;

                    Zombie_Count += 5;
                }

                else if (Zombie_Group_Count == 6)
                {
                    Debug.Log("This position is: " + Spawn_X_Position + ", 0, " + Spawn_Z_Position);
                    GameObject New_Zombie = Instantiate(Zombie_Type, new Vector3(Spawn_X_Position, 2.23f, Spawn_Z_Position), Quaternion.identity);
                    GameObject New_Zombie_2 = Instantiate(Zombie_Type, new Vector3(Spawn_X_Position + 1, 2.23f, Spawn_Z_Position), Quaternion.identity);
                    GameObject New_Zombie_3 = Instantiate(Zombie_Type, new Vector3(Spawn_X_Position - 1, 2.23f, Spawn_Z_Position), Quaternion.identity);
                    GameObject New_Zombie_4 = Instantiate(Zombie_Type, new Vector3(Spawn_X_Position, 2.23f, Spawn_Z_Position + 1), Quaternion.identity);
                    GameObject New_Zombie_5 = Instantiate(Zombie_Type, new Vector3(Spawn_X_Position, 2.23f, Spawn_Z_Position - 1), Quaternion.identity);
                    GameObject New_Zombie_6 = Instantiate(Zombie_Type, new Vector3(Spawn_X_Position + 2, 2.23f, Spawn_Z_Position), Quaternion.identity);

                    New_Zombie.transform.parent = Parent_Object;
                    New_Zombie_2.transform.parent = Parent_Object;
                    New_Zombie_3.transform.parent = Parent_Object;
                    New_Zombie_4.transform.parent = Parent_Object;
                    New_Zombie_5.transform.parent = Parent_Object;
                    New_Zombie_6.transform.parent = Parent_Object;

                    Zombie_Count += 6;
                }

                else if (Zombie_Group_Count == 7)
                {
                    Debug.Log("This position is: " + Spawn_X_Position + ", 0, " + Spawn_Z_Position);
                    GameObject New_Zombie = Instantiate(Zombie_Type, new Vector3(Spawn_X_Position, 2.23f, Spawn_Z_Position), Quaternion.identity);
                    GameObject New_Zombie_2 = Instantiate(Zombie_Type, new Vector3(Spawn_X_Position + 1, 2.23f, Spawn_Z_Position), Quaternion.identity);
                    GameObject New_Zombie_3 = Instantiate(Zombie_Type, new Vector3(Spawn_X_Position - 1, 2.23f, Spawn_Z_Position), Quaternion.identity);
                    GameObject New_Zombie_4 = Instantiate(Zombie_Type, new Vector3(Spawn_X_Position, 2.23f, Spawn_Z_Position + 1), Quaternion.identity);
                    GameObject New_Zombie_5 = Instantiate(Zombie_Type, new Vector3(Spawn_X_Position, 2.23f, Spawn_Z_Position - 1), Quaternion.identity);
                    GameObject New_Zombie_6 = Instantiate(Zombie_Type, new Vector3(Spawn_X_Position + 2, 2.23f, Spawn_Z_Position), Quaternion.identity);
                    GameObject New_Zombie_7 = Instantiate(Zombie_Type, new Vector3(Spawn_X_Position - 2, 2.23f, Spawn_Z_Position), Quaternion.identity);


                    New_Zombie.transform.parent = Parent_Object;
                    New_Zombie_2.transform.parent = Parent_Object;
                    New_Zombie_3.transform.parent = Parent_Object;
                    New_Zombie_4.transform.parent = Parent_Object;
                    New_Zombie_5.transform.parent = Parent_Object;
                    New_Zombie_6.transform.parent = Parent_Object;
                    New_Zombie_7.transform.parent = Parent_Object;

                    Zombie_Count += 7;
                }

                else if (Zombie_Group_Count == 8)
                {
                    Debug.Log("This position is: " + Spawn_X_Position + ", 0, " + Spawn_Z_Position);
                    GameObject New_Zombie = Instantiate(Zombie_Type, new Vector3(Spawn_X_Position, 2.23f, Spawn_Z_Position), Quaternion.identity);
                    GameObject New_Zombie_2 = Instantiate(Zombie_Type, new Vector3(Spawn_X_Position + 1, 2.23f, Spawn_Z_Position), Quaternion.identity);
                    GameObject New_Zombie_3 = Instantiate(Zombie_Type, new Vector3(Spawn_X_Position - 1, 2.23f, Spawn_Z_Position), Quaternion.identity);
                    GameObject New_Zombie_4 = Instantiate(Zombie_Type, new Vector3(Spawn_X_Position, 2.23f, Spawn_Z_Position + 1), Quaternion.identity);
                    GameObject New_Zombie_5 = Instantiate(Zombie_Type, new Vector3(Spawn_X_Position, 2.23f, Spawn_Z_Position - 1), Quaternion.identity);
                    GameObject New_Zombie_6 = Instantiate(Zombie_Type, new Vector3(Spawn_X_Position + 2, 2.23f, Spawn_Z_Position), Quaternion.identity);
                    GameObject New_Zombie_7 = Instantiate(Zombie_Type, new Vector3(Spawn_X_Position - 2, 2.23f, Spawn_Z_Position), Quaternion.identity);
                    GameObject New_Zombie_8 = Instantiate(Zombie_Type, new Vector3(Spawn_X_Position, 2.23f, Spawn_Z_Position + 2), Quaternion.identity);

                    New_Zombie.transform.parent = Parent_Object;
                    New_Zombie_2.transform.parent = Parent_Object;
                    New_Zombie_3.transform.parent = Parent_Object;
                    New_Zombie_4.transform.parent = Parent_Object;
                    New_Zombie_5.transform.parent = Parent_Object;
                    New_Zombie_6.transform.parent = Parent_Object;
                    New_Zombie_7.transform.parent = Parent_Object;
                    New_Zombie_8.transform.parent = Parent_Object;

                    Zombie_Count += 8;
                }

                else if (Zombie_Group_Count == 9)
                {
                    Debug.Log("This position is: " + Spawn_X_Position + ", 0, " + Spawn_Z_Position);
                    GameObject New_Zombie = Instantiate(Zombie_Type, new Vector3(Spawn_X_Position, 2.23f, Spawn_Z_Position), Quaternion.identity);
                    GameObject New_Zombie_2 = Instantiate(Zombie_Type, new Vector3(Spawn_X_Position + 1, 2.23f, Spawn_Z_Position), Quaternion.identity);
                    GameObject New_Zombie_3 = Instantiate(Zombie_Type, new Vector3(Spawn_X_Position - 1, 2.23f, Spawn_Z_Position), Quaternion.identity);
                    GameObject New_Zombie_4 = Instantiate(Zombie_Type, new Vector3(Spawn_X_Position, 2.23f, Spawn_Z_Position + 1), Quaternion.identity);
                    GameObject New_Zombie_5 = Instantiate(Zombie_Type, new Vector3(Spawn_X_Position, 2.23f, Spawn_Z_Position - 1), Quaternion.identity);
                    GameObject New_Zombie_6 = Instantiate(Zombie_Type, new Vector3(Spawn_X_Position + 2, 2.23f, Spawn_Z_Position), Quaternion.identity);
                    GameObject New_Zombie_7 = Instantiate(Zombie_Type, new Vector3(Spawn_X_Position - 2, 2.23f, Spawn_Z_Position), Quaternion.identity);
                    GameObject New_Zombie_8 = Instantiate(Zombie_Type, new Vector3(Spawn_X_Position, 2.23f, Spawn_Z_Position + 2), Quaternion.identity);
                    GameObject New_Zombie_9 = Instantiate(Zombie_Type, new Vector3(Spawn_X_Position, 2.23f, Spawn_Z_Position - 2), Quaternion.identity);

                    New_Zombie.transform.parent = Parent_Object;
                    New_Zombie_2.transform.parent = Parent_Object;
                    New_Zombie_3.transform.parent = Parent_Object;
                    New_Zombie_4.transform.parent = Parent_Object;
                    New_Zombie_5.transform.parent = Parent_Object;
                    New_Zombie_6.transform.parent = Parent_Object;
                    New_Zombie_7.transform.parent = Parent_Object;
                    New_Zombie_8.transform.parent = Parent_Object;
                    New_Zombie_9.transform.parent = Parent_Object;

                    Zombie_Count += 9;
                }

                yield return new WaitForSeconds(Random.Range(1, 6));
            }
        }
    }

    public void Random_Position_And_Type()
    {
        Zombie_Group_Count = Random.Range(1, 10);
        int Random_List_Position = Random.Range(0, Zombie_Spawning_Points.Count);
        int Random_Zombie_Type = Random.Range(0, Zombie_Type_Prefabs.Count);

        Vector3 Random_Spawning_Point = Zombie_Spawning_Points[Random_List_Position];
        Zombie_Type = Zombie_Type_Prefabs[Random_Zombie_Type];

        Spawn_X_Position = Random_Spawning_Point.x;
        Spawn_Z_Position = Random_Spawning_Point.z;
    }
}
