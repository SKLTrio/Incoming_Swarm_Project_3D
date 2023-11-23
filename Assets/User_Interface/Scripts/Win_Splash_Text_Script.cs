using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Win_Splash_Text_Script : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI Description_Splash_Text;

    public List<string> Description_Splash_Text_List = new List<string>();

    void Start()
    {
        if (Description_Splash_Text_List.Count > 0)
        {
            int Random_Index = Random.Range(0, Description_Splash_Text_List.Count);

            string Splash_Text = Description_Splash_Text_List[Random_Index];

            Description_Splash_Text.text = Splash_Text;
        }

        else
        {
            Debug.LogError("Description_Splash_Text_List is empty. Add some elements to the list.");
        }
    }
}
