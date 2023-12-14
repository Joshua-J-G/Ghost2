using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GuessMenu : MonoBehaviour
{
    public TMP_Text DisplayText;

    AI_Manager Top;
    AI_Manager Blank;
    AI_Manager Broken;

    public void AnomalyDetector()
    {

    }


    public void Guess(int ID)
    {
        switch(ID)
        {
            case 0:
                if(Top.Possessed)
                {
                    Top.Possessed = false;
                    GameManager.instance.ChooseEnemy();
                    Debug.Log("Correct");
                    GameManager.instance.currentPercentage = 0;

                }
                else
                {
                    Debug.Log("Dead");
                    GameManager.instance.EndScreen.SetActive(true);
                }
                break;
                case 1:
                if (Blank.Possessed)
                {
                    Blank.Possessed = false;
                    GameManager.instance.ChooseEnemy();
                    Debug.Log("Correct");
                    GameManager.instance.currentPercentage = 0;
                }
                else
                {
                    Debug.Log("Dead");
                    GameManager.instance.EndScreen.SetActive(true);
                }

                break; 
            case 2:
                if (Broken.Possessed)
                {
                    Broken.Possessed = false;
                    GameManager.instance.ChooseEnemy();
                    Debug.Log("Correct");
                    GameManager.instance.currentPercentage = 0;
                }
                else
                {
                    Debug.Log("Dead");
                    GameManager.instance.EndScreen.SetActive(true);
                }
                break;
        }
    }

    public void SetText(string texts)
    {
        DisplayText.text = texts;
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach(AI_Manager g in GameManager.instance.AI)
        {
            
            switch (g.ID)
            {
                case 0:
                    Top = g;
                    break;
                case 1:
                    Blank = g;
                    break;
                case 2:
                    Broken = g;
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
