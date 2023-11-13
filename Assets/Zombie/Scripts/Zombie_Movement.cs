using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Movement : MonoBehaviour
{
    public float Patrol_Speed = 2f;
    public float Chase_Speed = 5f;
    public float Turn_Speed = 5f;
    public float Patrol_Radius = 20f;
    public float Chase_Radius = 30f;
    public float Obstacle_Distance = 1f;

    private Transform Player_Object;

    private Vector3 Patrol_Destination;

    private bool Is_Chasing = false;

    void Start()
    {
        Player_Object = GameObject.FindGameObjectWithTag("Player").transform;

        Set_Random_Patrol_Destination();
    }

    void Update()
    {
        float Distance_To_Player = Vector3.Distance(transform.position, Player_Object.position);

        if (Distance_To_Player <= Chase_Radius)
        {
            Is_Chasing = true;
        }
        else if (Distance_To_Player > Chase_Radius * 1.5f)
        {
            Is_Chasing = false;
            Set_Random_Patrol_Destination();
        }

        if (Is_Chasing)
        {
            Chase_Player();
        }
        else
        {
            Patrol_Around();
        }
    }

    void Patrol_Around()
    {
        Quaternion Zombie_Rotation = Quaternion.LookRotation(Patrol_Destination - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, Zombie_Rotation, Turn_Speed * Time.deltaTime);

        transform.Translate(Vector3.forward * Patrol_Speed * Time.deltaTime);

        float Distance_To_Destination = Vector3.Distance(transform.position, Patrol_Destination);

        if (Distance_To_Destination < 1.0f || Check_For_Obstacle())
        {
            Set_Random_Patrol_Destination();
        }
    }

    void Chase_Player()
    {
        Quaternion Rotation = Quaternion.LookRotation(Player_Object.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, Rotation, Turn_Speed * Time.deltaTime);

        transform.Translate(Vector3.forward * Chase_Speed * Time.deltaTime);
    }

    void Set_Random_Patrol_Destination()
    {
        float Random_X_Position = Random.Range(-Patrol_Radius, Patrol_Radius);
        float Random_Z_Position = Random.Range(-Patrol_Radius, Patrol_Radius);

        Patrol_Destination = new Vector3(transform.position.x + Random_X_Position, transform.position.y, transform.position.z + Random_Z_Position);
    }

    public bool Check_For_Obstacle()
    {
        RaycastHit Hit;

        if (Physics.Raycast(transform.position, transform.forward, out Hit, Obstacle_Distance))
        {
            if (Hit.collider.CompareTag("Zombie_Obstacle"))
            {
                return true;
            }
        }

        return false;
    }
} 