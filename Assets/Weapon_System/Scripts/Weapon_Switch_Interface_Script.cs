using UnityEngine;
using UnityEngine.UI;

public class Weapon_Switch_Interface_Script : MonoBehaviour
{

    public int Selected_Weapon = 0;
    public GameObject[] Weapon_Images;
    public GameObject[] Weapon_Ammo_Images;

    void Start()
    {
        Select_Weapon();
    }

    void Update()
    {
        int Previously_Selected_Weapon = Selected_Weapon;

        float Scroll_Wheel_Value = Input.mouseScrollDelta.y;

        if (Scroll_Wheel_Value < 0f)
        {
            if (Selected_Weapon >= transform.childCount - 1)
            {
                Selected_Weapon = 0;
            }

            else
            {
                Selected_Weapon++;
            }
        }

        if (Scroll_Wheel_Value > 0f)
        {
            if (Selected_Weapon <= 0)
            {
                Selected_Weapon = transform.childCount - 1;
            }

            else
            {
                Selected_Weapon--;
            }
        }

        if (Previously_Selected_Weapon != Selected_Weapon)
        {
            Select_Weapon();
        }

    }

    void Select_Weapon()
    {

        int i = 0;

        foreach (Transform Weapon in transform)
        {
            if (i == Selected_Weapon)
            {
                Weapon.gameObject.SetActive(true);
                Weapon_Images[i].SetActive(true);
                Weapon_Ammo_Images[i].SetActive(true);
                //Weapon.GetComponent<Gun_Script>().Set_Has_Ammo(true);
            }

            else
            {
                Weapon.gameObject.SetActive(false);
                Weapon_Images[i].SetActive(false);
                Weapon_Ammo_Images[i].SetActive(false);
                //Weapon.GetComponent<Gun_Script>().Set_Has_Ammo(false);
            }

            i++;
        }
    }

}
