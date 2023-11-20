using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI Timer_Text;
    
    void Start()
    {
        Update_Time_UI(600f);
    }

    public void Update_Time_UI(float Current_Time)
    {
        int Seconds = (int)Current_Time;
        Timer_Text.text = System.TimeSpan.FromSeconds(Seconds).ToString("mm':'ss");
    }
}
