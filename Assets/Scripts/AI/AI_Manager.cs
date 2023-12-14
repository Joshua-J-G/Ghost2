using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Manager : MonoBehaviour
{
    public Ai_Point currentPoint;

    public List<Ai_Point> points;

    public bool GhostSelected = false;

    [SerializeField]float timerTillNextMove;

    public int ID;

    //1-10
    public int Ailevel = 1;

   [SerializeField] bool canMove = false;

    public bool Possessed = false;

    private void Start()
    {
        timerTillNextMove = 10f + Ailevel + Random.Range(0, 10);

        foreach (Ai_Point p in points) 
        {
            if(p != currentPoint)
            {
                p.gameObject.SetActive(false);
            }
        }
    }

    IEnumerator DoItAnyway()
    {
        yield return new WaitForSeconds(3f);
        if (canMove)
        {
            canMove = false;
            //Debug.Log(currentPoint.C_pCamera.isPlayerLookingAtCamera);
            if (currentPoint.C_pCamera != null && currentPoint.C_pCamera.isPlayerLookingAtCamera)
            {
                GameManager.instance.BlinkScreen();
            }

           

            GameObject temp = currentPoint.GetMove(Possessed, Ailevel);
            currentPoint.gameObject.SetActive(false);
            currentPoint = temp.GetComponent<Ai_Point>();
            currentPoint.gameObject.SetActive(true);
            currentPoint.Paranomal(Ailevel);
        }

        
  
    }

    private void Update() 
    {

        if(!GhostSelected)
        {
            return;
        }

        if(!canMove)
        {
            timerTillNextMove -= Time.deltaTime;
        }

        if(timerTillNextMove < 0 && !canMove)
        {
            
            timerTillNextMove = 5f + Ailevel + Random.Range(0, 10);
            canMove = true;
        }


        if (currentPoint.C_pCamera != null && !currentPoint.C_pCamera.isPlayerLookingAtCamera)
        {
            if (canMove)
            {
                Debug.Log(currentPoint.C_pCamera.isPlayerLookingAtCamera);
                if(currentPoint.C_pCamera.isPlayerLookingAtCamera)
                {
                    GameManager.instance.BlinkScreen();
                }
               
                StopAllCoroutines();
                canMove = false;

                GameObject temp = currentPoint.GetMove(Possessed, Ailevel);
                currentPoint.gameObject.SetActive(false);
                currentPoint = temp.GetComponent<Ai_Point>();
                currentPoint.gameObject.SetActive(true);
                if (currentPoint.C_pCamera != null && currentPoint.C_pCamera.isPlayerLookingAtCamera)
                {
                    GameManager.instance.BlinkScreen();
                }
            }
        }
        else
        {
            StartCoroutine(DoItAnyway());
        }
    }

}
