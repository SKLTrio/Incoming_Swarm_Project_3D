using System.Collections;
using UnityEngine;

public class Zombie_Health_Script : MonoBehaviour
{
    public float Zombie_Health = 100f;
    public float Zombie_Knockback_Force = 1f;
    public float Red_Flash_Time = 0.5f;

    public Rigidbody Zombie_Rigid_Body;

    //public Renderer Zombie_Head_Renderer;
    //public Renderer Zombie_Body_Renderer;

    //private Color Original_Zombie_Color_Head;
    //private Color Original_Zombie_Color_Body;


    private void Start()
    {
        Zombie_Rigid_Body = GetComponent<Rigidbody>();

        //Zombie_Head_Renderer = GetComponent<Renderer>();
        //Zombie_Body_Renderer = GetComponent<Renderer>();

        //Original_Zombie_Color_Head = Zombie_Head_Renderer.material.color;
        //Original_Zombie_Color_Body = Zombie_Body_Renderer.material.color;
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

    //IEnumerator Flash_Red()
    //{
        //Zombie_Head_Renderer.material.color = Color.red;
        //Zombie_Body_Renderer.material.color = Color.red;

        //yield return new WaitForSeconds(Red_Flash_Time);

        //Zombie_Head_Renderer.material.color = Original_Zombie_Color_Head;
        //Zombie_Body_Renderer.material.color = Original_Zombie_Color_Body;

    //}

    void Zombie_Death()
    {
        Collider Zombie_Collider = GetComponent<Collider>();

        if (Zombie_Collider != null)
        {
            Zombie_Collider.enabled = false;
        }

        Destroy(gameObject);
    }

}
