using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Menu_Controller : MonoBehaviour
{
    [SerializeField]
    public string Start_Scene;

    [SerializeField]
    public string Game_Scene;

    [SerializeField]
    public GameObject Pause_Menu_Panel;

    [SerializeField]
    public GameObject How_To_Play_Menu_Main;

    [SerializeField]
    public GameObject How_To_Play_Menu_Secondary;

    [SerializeField]
    public GameObject How_To_Play_Menu_Third;

    [SerializeField]
    public GameObject How_To_Play_Menu_Fourth;

    [SerializeField]
    public GameObject Control_Menu_Main;

    [SerializeField]
    public GameObject Control_Menu_Secondary;

    [SerializeField]
    public GameObject Win_Panel;

    [SerializeField]
    public bool Is_Pause_Menu_Available = false;

    [SerializeField]
    public bool Is_Game_Paused = false;

    public void Update()
    {
        if (Is_Pause_Menu_Available)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (Is_Game_Paused)
                {
                    Resume_Game();
                }

                else
                {
                    Pause_Game();
                }
            }
        }
    }

    public void Pause_Game()
    {
        Pause_Menu_Panel.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Is_Game_Paused = true;
        Time.timeScale = 0f;
    }

    public void Resume_Game()
    {
        Pause_Menu_Panel.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Is_Game_Paused = false;
        Time.timeScale = 1f;
        
    }

    public void Return_To_Main_Menu()
    {
        Cursor.visible = true;
        SceneManager.LoadScene(Start_Scene);
    }

    public void Start_Game()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SceneManager.LoadScene(Game_Scene);
        Time.timeScale = 1f;
    }

    public void Quit_Game()
    {
        Debug.Log("You Have Quit The Game!");
        Application.Quit();
    }

    public void Open_How_To_Menu_Main()
    {
        How_To_Play_Menu_Main.SetActive(true);
    }

    public void Close_How_To_Menu_Main()
    {
        How_To_Play_Menu_Main.SetActive(false);
    }

    public void Open_How_To_Menu_Secondary()
    {
        How_To_Play_Menu_Secondary.SetActive(true);
    }

    public void Close_How_To_Menu_Secondary()
    {
        How_To_Play_Menu_Secondary.SetActive(false);
    }

    public void Open_How_To_Menu_Third()
    {
        How_To_Play_Menu_Third.SetActive(true);
    }

    public void Close_How_To_Menu_Third()
    {
        How_To_Play_Menu_Third.SetActive(false);
    }

    public void Open_How_To_Menu_Fourth()
    {
        How_To_Play_Menu_Fourth.SetActive(true);
    }

    public void Close_How_To_Menu_Fourth()
    {
        How_To_Play_Menu_Fourth.SetActive(false);
    }

    public void Open_Control_Menu_Main()
    {
        Control_Menu_Main.SetActive(true);
    }

    public void Close_Control_Menu_Main()
    {
        Control_Menu_Main.SetActive(false);
    }

    public void Open_Control_Menu_Secondary()
    {
        Control_Menu_Secondary.SetActive(true);
    }

    public void Close_Control_Menu_Secondary()
    {
        Control_Menu_Secondary.SetActive(false);
    }

    public void Open_Death_Panel()
    {

    }

    public void Close_Death_Panel()
    {

    }

    public void Open_Win_Panel()
    {
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Win_Panel.SetActive(true);
    }
    public void Close_Win_Panel()
    {

    }
}
