using System.Collections;
using UnityEngine;

public class Zombie_Health_Script : MonoBehaviour
{
    public float Zombie_Health = 100f;
    public float Zombie_Knockback_Force = 1f;
    public float Red_Flash_Time = 0.5f;

    public Rigidbody Zombie_Rigid_Body;

    public Zombie_Spawning Zombie_Spawning_Script;

    private void Start()
    {
        Zombie_Spawning_Script = FindObjectOfType<Zombie_Spawning>();
        Zombie_Rigid_Body = GetComponent<Rigidbody>();
    }

    public void Take_Damage(float Damage)
    {
        Zombie_Health -= Damage;
        Zombie_Rigid_Body.AddForce(-transform.forward * Zombie_Knockback_Force, ForceMode.Impulse);
        //StartCoroutine(Flash_Red());

        if (Zombie_Health <= 0)
        {
            Zombie_Death();
        }

    }

    void Zombie_Death()
    {
        Collider Zombie_Collider = GetComponent<Collider>();

        if (Zombie_Collider != null)
        {
            Zombie_Collider.enabled = false;
        }

        Destroy(gameObject);
        Zombie_Spawning_Script.Zombie_Count -= 1;
    }

}
