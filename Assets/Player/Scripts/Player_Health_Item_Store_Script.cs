using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Player_Health_Item_Store_Script : MonoBehaviour
{
    [SerializeField]
    public int Health_Item_Count;

    [SerializeField]
    public bool Is_Item_On_Cooldown = false;

    [SerializeField]
    public TextMeshProUGUI Health_Item_Count_Text;

    [SerializeField]
    public GameObject Full_Health_Already_Text;

    [SerializeField]
    public GameObject No_Health_Items_Text;

    [SerializeField]
    public Image UI_Health_Image;

    [SerializeField]
    public GameObject Player_Object;

    public void On_Use(InputAction.CallbackContext Context)
    {
        if (!Is_Item_On_Cooldown)
        {
            StartCoroutine(Use_Health_Item());
        }
    }

    public void Start()
    {
        Full_Health_Already_Text.SetActive(false);
        No_Health_Items_Text.SetActive(false);
    }

    public void Update()
    {
        Health_Item_Count_Text.text = "x " + Health_Item_Count.ToString(); 
    }

    IEnumerator Use_Health_Item()
    {
        Is_Item_On_Cooldown = true;

        Player_Health_Script Player_Health_Script = Player_Object.GetComponent<Player_Health_Script>();
        if (Health_Item_Count > 0)
        {
            if (Player_Health_Script.Health != 100)
            {
                Health_Item_Count--;

                int Health_Boost = Random.Range(5, 36);

                if (Player_Health_Script != null)
                {
                    Player_Health_Script.Health += Health_Boost;
                    StartCoroutine(Set_Health_Add_Panel());
                    if (Player_Health_Script.Health > 100)
                    {
                        Player_Health_Script.Health = Player_Health_Script.Max_Health;
                    }

                    Player_Health_Script.Set_Health_Slider();
                    Debug.Log(Health_Boost);
                }

                Health_Item_Count_Text.text = "x " + Health_Item_Count.ToString();
                
            }

            else
            {
                StartCoroutine(Set_Full_Health_Text());
            }
        }

        else
        {
            StartCoroutine(Set_No_Health_Items_Text());
        }

        yield return new WaitForSeconds(3f);
        Is_Item_On_Cooldown = false;

    }

    IEnumerator Set_Full_Health_Text()
    {
        Full_Health_Already_Text.SetActive(true);
        yield return new WaitForSeconds(1f);
        Full_Health_Already_Text.SetActive(false);
    }

    IEnumerator Set_No_Health_Items_Text()
    {
        No_Health_Items_Text.SetActive(true);
        yield return new WaitForSeconds(1f);
        No_Health_Items_Text.SetActive(false);
    }

    IEnumerator Set_Health_Add_Panel()
    {
        if (UI_Health_Image != null)
        {
            float Image_Alpha;

            for (Image_Alpha = 0f; Image_Alpha <= 0.1f; Image_Alpha += 0.01f)
            {
                Color Current_Image_Colour = UI_Health_Image.color;
                Current_Image_Colour.a = Image_Alpha;
                UI_Health_Image.color = Current_Image_Colour;

                yield return new WaitForSeconds(0.05f);
            }

            yield return new WaitForSeconds(.75f);

            for (Image_Alpha = 0.1f; Image_Alpha >= 0f; Image_Alpha -= 0.01f)
            {
                Color Current_Image_Colour = UI_Health_Image.color;
                Current_Image_Colour.a = Image_Alpha;
                UI_Health_Image.color = Current_Image_Colour;

                yield return new WaitForSeconds(0.05f);
            }
        }

        else
        {
            Debug.Log("Image Component not found!");
        }
    }
}
