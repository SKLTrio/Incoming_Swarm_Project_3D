using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player_Health_Script : MonoBehaviour
{
    public float Max_Health = 100f;
    public float Min_Health = 0f;
    public float Health;

    public Slider Health_Slider;

    void Start()
    {
        Health = Max_Health;
    }

    void Update()
    {
        if (Health < 0)
        {
            Health = 0;
        }
    }

    public void Take_Damage(float Zombie_Damage)
    {
        Health -= Zombie_Damage;

        Health = Mathf.Max(Health, Min_Health);

        Set_Health_Slider();
        
        if (Health <= Min_Health)
        {
            On_Death();
        }

    }

    public void Set_Health_Slider()
    {
        if (Health_Slider != null)
        {
            Health_Slider.value = Normalised_Hit_Points();
        }
    }

    public float Normalised_Hit_Points()
    {
        return Health / Max_Health;
    }

    public void On_Death()
    {
        UnityEngine.Debug.Log("GAME OVER - YOU DIED");
        //GameManager.Instance.GameOver();
        //DeathPanel.SetActive(true);
        //Cursor.visible = true;
    }

}
