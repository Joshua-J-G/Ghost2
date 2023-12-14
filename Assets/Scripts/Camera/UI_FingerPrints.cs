using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_FingerPrints : MonoBehaviour
{
    public List<GameObject> Fingerprints = new();

    GameObject SelectedFingerpirnt;
    C_Point CameraWithFingerprint;

    public static UI_FingerPrints instance;

    IEnumerator RemoveAllVisableAfterSeconds()
    {
        yield return new WaitForSeconds(4f);
        CameraWithFingerprint = null;
        SelectedFingerpirnt.SetActive(false);
        SelectedFingerpirnt = null;
    }
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }else
        {
            Destroy(this);
        }
    }


    public void FingerPrints(C_Point CameraLocation)
    {
        CameraWithFingerprint = CameraLocation;
        if (SelectedFingerpirnt != null)
            SelectedFingerpirnt.SetActive(false);
        SelectedFingerpirnt = Fingerprints[Random.Range(0, Fingerprints.Count)];
    }

    public void CameraUpdated()
    {
            if (C_Manager.instance.CameraLocation == CameraWithFingerprint)
            {

            if (SelectedFingerpirnt != null && CameraWithFingerprint != null)
            {
                StopAllCoroutines();
                SelectedFingerpirnt.SetActive(true);
                StartCoroutine(RemoveAllVisableAfterSeconds());
            }
            }
            else
            {
              if(SelectedFingerpirnt != null)
                SelectedFingerpirnt.SetActive(false);
            }
        
    }


    // Update is called once per frame
    void Update()
    {
       
    }
}
