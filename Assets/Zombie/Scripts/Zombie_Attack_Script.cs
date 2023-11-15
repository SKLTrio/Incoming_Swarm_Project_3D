using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Attack_Script : MonoBehaviour
{
    public float Zombie_Strength;
    public float Zombie_Attack_Distance;
    public float Zombie_Attack_Cooldown_Speed;

    private bool Can_Attack = true;

    private Player_Health_Script Player_Health_Script;

    private void Start()
    {
        Player_Health_Script = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Health_Script>();
    }

    private void Update()
    {
        float Distance_To_Player = Vector3.Distance(transform.position, Player_Health_Script.transform.position);

        if (Distance_To_Player <= Zombie_Attack_Distance && Can_Attack)
        {
            Attack_Player();
            StartCoroutine(Cooldown_Period());
        }
    }

    public void Attack_Player()
    {
        Player_Health_Script.Take_Damage(Zombie_Strength);
    }

    public IEnumerator Cooldown_Period()
    {
        Can_Attack = false;
        yield return new WaitForSeconds(Zombie_Attack_Cooldown_Speed);
        Can_Attack = true;
    }

}
