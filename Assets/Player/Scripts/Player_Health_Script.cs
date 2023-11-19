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

    public Image UI_Damage_Image;
    public GameObject UI_Blood_Splatter_Image;

    void Start()
    {
        Health = Max_Health;
        UI_Blood_Splatter_Image.SetActive(false);
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

        StartCoroutine(Set_Damage_Panel());

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

    IEnumerator Set_Damage_Panel()
    {
        if (UI_Damage_Image != null)
        {
            float Image_Alpha;

            for (Image_Alpha = 0f; Image_Alpha <=0.1f; Image_Alpha += 0.01f)
            {
                Color Current_Image_Colour = UI_Damage_Image.color;
                Current_Image_Colour.a = Image_Alpha;
                UI_Damage_Image.color = Current_Image_Colour;
                UI_Blood_Splatter_Image.SetActive(true);

                yield return new WaitForSeconds(0.05f);
            }

            yield return new WaitForSeconds(.75f);

            for (Image_Alpha = 0.1f; Image_Alpha >= 0f; Image_Alpha -= 0.01f)
            {
                Color Current_Image_Colour = UI_Damage_Image.color;
                Current_Image_Colour.a = Image_Alpha;
                UI_Damage_Image.color = Current_Image_Colour;
                UI_Blood_Splatter_Image.SetActive(false);

                yield return new WaitForSeconds(0.05f);
            }
        }

        else
        {
            Debug.Log("Image Component not found!");
        }
    }

    public void On_Death()
    {
        UnityEngine.Debug.Log("GAME OVER - YOU DIED");
        //GameManager.Instance.GameOver();
        //DeathPanel.SetActive(true);
        //Cursor.visible = true;
    }

}
