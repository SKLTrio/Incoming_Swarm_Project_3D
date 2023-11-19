using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class Shotgun_Gun_Script : MonoBehaviour
{
    public float Damage = 0f;
    public float Range = 100f;
    public float Impact_Force = 30f;

    //The greater the fire rate, the less time between shots. So lower is slower.
    public float Fire_Rate = 15f;

    public int Max_Ammo = 0;
    private int Current_Ammo;
    public float Reload_Time = 3f;
    private bool Is_Reloading = false;

    [SerializeField]
    Transform Camera_Transform;

    public ParticleSystem Muzzle_Flash;

    private float Next_Time_To_Fire = 0f;

    public Animator animator;

    public GameObject Ammo_Sprite_Object;

    public bool Has_Ammo = false;

    public Camera Player_Camera;

    public GameObject HUD_Cross_Hair;
    public GameObject Shotgun_Cross_Hair;

    public float Normal_FOV = 60f;
    public float Zoom_FOV = 40f;

    public Vector3 Recoil_Position = new Vector3(0f, 0f, -0.2f);
    public Vector3 Camera_Recoil_Position = new Vector3(0f, 0.15f, -0.2f);
    public Vector3 Original_Gun_Position;

    public Vector3 Original_Camera_Recoil_Position;

    public TextMeshProUGUI Gun_Ammo_Text;
    public GameObject Gun_Reloading_Text;

    private bool Is_Zoom_Enabled;

    [SerializeField]
    Player_Locomotion Player_Locomotion_Script;

    [SerializeField]
    Weapon_Switch_Interface_Script Weapon_Interface_Script;

    [SerializeField]
    Shotgun_Reload_Script Shotgun_Reload_Script;

    public void On_Zoom(InputAction.CallbackContext Context)
    {
        if (Context.started)
        {
            Zoom_In();
        }

        else if (Context.canceled)
        {
            Zoom_Out();
        }
    }

    private void Start()
    {
        Player_Locomotion_Script = FindObjectOfType<Player_Locomotion>();

        if (Player_Locomotion_Script == null)
        {
            Debug.LogError("Player_Locomotion script not found in the scene.");
        }
        else
        {
            Weapon_Interface_Script = FindObjectOfType<Weapon_Switch_Interface_Script>();
            Shotgun_Reload_Script = FindObjectOfType<Shotgun_Reload_Script>();

            Camera_Transform = Camera.main.transform;
            Original_Gun_Position = transform.localPosition;
            Current_Ammo = Max_Ammo;
            Shotgun_Cross_Hair.SetActive(false);
            Gun_Reloading_Text.SetActive(false);
        }
    }

    private void OnEnable()
    {
        Is_Reloading = false;
        animator.SetBool("Reloading", false);
    }

    void Update()
    {
        if (Is_Reloading)
        {
            return;
        }

        if (Current_Ammo <= 0)
        {
            StartCoroutine(Reload_Gun());
            return;
        }

        if (Mouse.current.leftButton.isPressed && Time.time >= Next_Time_To_Fire)
        {
            Next_Time_To_Fire = Time.time + 1f / Fire_Rate;
            Shoot();
        }
    }

    IEnumerator Reload_Gun()
    {
        Is_Reloading = true;

        Debug.Log("Reloading!");

        Gun_Reloading_Text.SetActive(true);

        animator.SetBool("Reloading", true);

        yield return new WaitForSeconds(Reload_Time - 0.25f);

        Shotgun_Reload_Script.Reload_Gun();

        animator.SetBool("Reloading", false);

        Gun_Reloading_Text.SetActive(false);

        yield return new WaitForSeconds(0.25f);

        Current_Ammo = Max_Ammo;
        Gun_Ammo_Text.text = "x " + Current_Ammo.ToString();
        Gun_Ammo_Text.color = Color.white;

        Is_Reloading = false;

        if (Shotgun_Reload_Script.Current_Bullet_Amount_In_Clip <= 0)
        {
            Gun_Ammo_Text.text = "x 0";
            Gun_Ammo_Text.color = Color.red;
        }

    }

    public void Shoot()
    {

        if (Shotgun_Reload_Script.Current_Bullet_Amount_In_Clip <= 0 && Shotgun_Reload_Script.Current_Clip_Amount <= 0)
        {
            Debug.Log("NO AMMO!!!");
            Gun_Ammo_Text.text = "x 0";
            Gun_Ammo_Text.color = Color.red;
            return;
        }

        Muzzle_Flash.Play();
        RaycastHit Hit_Info;

        Vector3 Ray_Start_Point = Camera_Transform.position + Camera_Transform.forward * 1.5f;
        Debug.DrawRay(Ray_Start_Point, Camera_Transform.transform.forward * Range, Color.red);

        Current_Ammo--;
        Shotgun_Reload_Script.Current_Bullet_Amount_In_Clip--;
        Gun_Ammo_Text.color = Color.white;
        Gun_Ammo_Text.text = "x " + Current_Ammo.ToString();

        Camera_Transform = Camera.main.transform;

        StartCoroutine(Add_Recoil());

        if (Physics.Raycast(Ray_Start_Point, Camera_Transform.forward, out Hit_Info, Range - 1.5f))
        {
            Transform Hit_Transform = Hit_Info.transform;

            if (Hit_Info.collider.CompareTag("Zombie"))
            {
                Debug.Log("YOU HIT A ZOMBIE");

                Zombie_Health_Script Zombie_Health_Script = Hit_Info.transform.GetComponent<Zombie_Health_Script>();

                if (Zombie_Health_Script != null)
                {
                    Zombie_Health_Script.Take_Damage(Damage);
                }
                else
                {
                    Debug.Log("Target_Script not found on hit object: " + Hit_Info.transform.name);
                }
            }
            else if (Hit_Info.collider.CompareTag("Zombie_Head"))
            {
                Debug.Log("ZOMBIE HEADSHOT");

                Zombie_Health_Script Zombie_Health_Script = Hit_Info.transform.parent.GetComponent<Zombie_Health_Script>();

                if (Zombie_Health_Script != null)
                {
                    Zombie_Health_Script.Take_Damage(Damage * 2f);
                }
                else
                {
                    Zombie_Health_Script = Hit_Info.transform.GetComponent<Zombie_Health_Script>();

                    if (Zombie_Health_Script != null)
                    {
                        Zombie_Health_Script.Take_Damage(Damage * 2f);
                    }
                    else
                    {
                        Debug.Log("Target_Script not found on hit object or its parent: " + Hit_Info.transform.name);
                    }
                }
            }
            else
            {
                Debug.Log("Object hit, but does not have the 'Zombie' or 'Zombie_Head' tag.");
            }
        }
    }

    public void Set_Has_Ammo(bool HasAmmo)
    {
        Has_Ammo = HasAmmo;
    }

    public void Zoom_In()
    {
        if (Player_Camera == null)
        {
            Debug.LogError("Player_Camera is not assigned.");
            return;
        }

        Player_Camera.fieldOfView = Zoom_FOV;
        HUD_Cross_Hair.SetActive(false);

        if (Player_Locomotion_Script != null)
        {
            Player_Locomotion_Script.Mouse_Sensitivity = 0.01f;
            Player_Locomotion_Script.Speed = 1f;
            Player_Locomotion_Script.Sprint_Speed = 1f;
        }

        else
        {
            Debug.LogError("Player_Locomotion_Script is not assigned.");
            return;
        }

        Is_Zoom_Enabled = true;

        if (Weapon_Interface_Script != null)
        {
            if (Weapon_Interface_Script.Selected_Weapon == 2 && !Is_Reloading)
            {
                Shotgun_Cross_Hair.SetActive(true);
            }

            else
            {
                Shotgun_Cross_Hair.SetActive(false);
            }
        }

        else
        {
            Debug.LogError("Weapon_Interface_Script is not assigned.");
            return;
        }
    }

    public void Zoom_Out()
    {
        Player_Camera.fieldOfView = Normal_FOV;

        Shotgun_Cross_Hair.SetActive(false);

        Is_Zoom_Enabled = false;

        HUD_Cross_Hair.SetActive(true);

        Player_Locomotion_Script.Mouse_Sensitivity = 0.1f;
        Player_Locomotion_Script.Speed = 8f;
        Player_Locomotion_Script.Sprint_Speed = 15f;

    }

    IEnumerator Add_Recoil()
    {
        if (Is_Zoom_Enabled == true)
        {
            Player_Camera.transform.localPosition = Original_Camera_Recoil_Position;
            Player_Camera.transform.localRotation = Quaternion.Euler(0, 0, 0);

            Player_Camera.transform.localPosition += Camera_Recoil_Position;

            yield return new WaitForSeconds(0.1f);

            Player_Camera.transform.localPosition = Original_Camera_Recoil_Position;
            Player_Camera.transform.localRotation = Quaternion.Euler(0, 0, 0);

        }

        else
        {
            transform.localPosition = Original_Gun_Position;

            transform.localPosition += Recoil_Position;

            yield return new WaitForSeconds(0.1f);

            transform.localPosition = Original_Gun_Position;
        }
    }
}
