using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Background_Flickering_Script : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> Light_Game_Objects = new List<GameObject>();

    private bool Is_True;

    private void OnEnable()
    {
        Is_True = true;
        StartCoroutine(Flickering_Lights());
    }

    private void OnDisable()
    {
        Is_True = false;
        StopAllCoroutines();
    }

    private IEnumerator Flickering_Lights()
    {
        while (Is_True)
        {
            GameObject Random_Light_Choice_1 = Light_Game_Objects[Random.Range(0, Light_Game_Objects.Count)];
            GameObject Random_Light_Choice_2 = Light_Game_Objects[Random.Range(0, Light_Game_Objects.Count)];
            GameObject Random_Light_Choice_3 = Light_Game_Objects[Random.Range(0, Light_Game_Objects.Count)];
            GameObject Random_Light_Choice_4 = Light_Game_Objects[Random.Range(0, Light_Game_Objects.Count)];
            GameObject Random_Light_Choice_5 = Light_Game_Objects[Random.Range(0, Light_Game_Objects.Count)];
            GameObject Random_Light_Choice_6 = Light_Game_Objects[Random.Range(0, Light_Game_Objects.Count)];

            foreach (var Light_Game_Object in Light_Game_Objects)
            {
                Light_Game_Object.SetActive(false);
            }

            Random_Light_Choice_1.SetActive(true);
            Random_Light_Choice_2.SetActive(false);
            Random_Light_Choice_3.SetActive(true);
            Random_Light_Choice_4.SetActive(false);
            Random_Light_Choice_5.SetActive(true);
            Random_Light_Choice_6.SetActive(false);

            yield return new WaitForSeconds(.25f);

            Random_Light_Choice_1.SetActive(false);
            Random_Light_Choice_2.SetActive(true);
            Random_Light_Choice_3.SetActive(false);
            Random_Light_Choice_4.SetActive(true);
            Random_Light_Choice_5.SetActive(false);
            Random_Light_Choice_6.SetActive(true);

            yield return new WaitForSeconds(.25f);

            Random_Light_Choice_1.SetActive(true);
            Random_Light_Choice_2.SetActive(false);
            Random_Light_Choice_3.SetActive(true);
            Random_Light_Choice_4.SetActive(false);
            Random_Light_Choice_5.SetActive(true);
            Random_Light_Choice_6.SetActive(false);

            yield return new WaitForSeconds(.25f);

            Random_Light_Choice_1.SetActive(false);
            Random_Light_Choice_2.SetActive(true);
            Random_Light_Choice_3.SetActive(false);
            Random_Light_Choice_4.SetActive(true);
            Random_Light_Choice_5.SetActive(false);
            Random_Light_Choice_6.SetActive(true);

            yield return new WaitForSeconds(.25f);

            foreach (var Light_Game_Object in Light_Game_Objects)
            {
                Light_Game_Object.SetActive(false);
            }

            yield return new WaitForSeconds(.5f);
        }
    }
}
