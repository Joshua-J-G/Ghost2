using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnomalyDetector : MonoBehaviour
{
    public AI_Manager TOp, NotTop, B;
    public GameObject adet, andet;

    public TMP_Text anomalyDetector;

    int currentamount;

    IEnumerator hidesign()
    {
        yield return new WaitForSeconds(2);
        andet.SetActive(false);
        adet.SetActive(false);
    }

    public void Start()
    {
        adet.SetActive(false);
        andet.SetActive(false);
    }

    public void StartAnymolyDetection()
   {
        if(currentamount == 4)
        {

            return;
        }
        currentamount++;
        anomalyDetector.text = currentamount.ToString() + "/4";

       bool showsign = false;

      Debug.Log(gameObject.transform.parent.gameObject.name);

      if(TOp.currentPoint.C_pCamera == gameObject.transform.parent.gameObject.GetComponent<C_Point>())
      {
            if(TOp.Possessed)
            {
                showsign = true;
            }
      }

        if (NotTop.currentPoint.C_pCamera == gameObject.transform.parent.gameObject.GetComponent<C_Point>())
        {
            if (NotTop.Possessed)
            {
                showsign = true;
            }
        }

      

        if (B.currentPoint.C_pCamera == gameObject.transform.parent.gameObject.GetComponent<C_Point>())
        {
            if (B.Possessed)
            {
                showsign = true;
            }
        }
        
        if(showsign)
        {
            StopCoroutine("hidesign");
            adet.SetActive(true);
            andet.SetActive(false);
            StartCoroutine("hidesign");
        }
        else
        {
            StopCoroutine("hidesign");
            adet.SetActive(false);
            andet.SetActive(true);
            StartCoroutine("hidesign");
        }


    }
}
