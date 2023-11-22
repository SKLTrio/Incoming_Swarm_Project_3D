using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Menu_Controller Menu_Controller_Script;
    public UI_Manager UI_Manager_Script;

    private float Start_Timer_Seconds = 600f;
    private float End_Time;

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
        float Current_Time = Start_Timer_Seconds -= Time.deltaTime;
        UI_Manager_Script.Update_Time_UI(Current_Time);

        if (Current_Time <= 0)
        {
            Time.timeScale = 0f;
            
        }

    }


}
