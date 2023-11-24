using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Menu_Controller Menu_Controller_Script;
    public UI_Manager UI_Manager_Script;

    private float Start_Timer_Seconds = 300f;
    public bool Is_Win = false;

    public float Current_Time;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
    }

    private void Update()
    {
        Current_Time = Start_Timer_Seconds -= Time.deltaTime;
        UI_Manager_Script.Update_Time_UI(Current_Time);

        if (Current_Time <= 0)
        {
            Is_Win = true;
            Menu_Controller_Script.Open_Win_Panel();
        }

    }


}
