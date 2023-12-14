using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_Point : MonoBehaviour
{
    public List<GameObject> LegalMoves = new();
    public List<GameObject> IlegalMoves = new();

    public C_Point C_pCamera;



    public GameObject GetMove(bool Possessed, int ailevel)
    {
        if (Possessed)
        {
            if (Random.Range(0, 6) > 4 && IlegalMoves.Count != 0)
            {
                Paranomal(ailevel);



                return IlegalMoves[Random.Range(0, IlegalMoves.Count)];

            }
            else
            {
                Paranomal(ailevel);
                return LegalMoves[Random.Range(0, LegalMoves.Count)];
            }
        }else
        {
            return LegalMoves[Random.Range(0, LegalMoves.Count)];
        }
    }

   
    public void Paranomal(int Ailevel)
    {
        if (Random.Range(0, 20) > (16 - (10-Ailevel)))
        {
            if (C_pCamera != null)
            {
                switch (Random.Range(0, 2))
                {
                    case 0:
                        C_pCamera.LOCKBUTTON();
                        break;
                    case 1:
                        C_pCamera.FingerPrint();
                        UI_FingerPrints.instance.CameraUpdated();
                        break;
                    case 2:
                        Debug.Log("idk");
                        break;
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
