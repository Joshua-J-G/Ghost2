using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.Collections;
using UnityEngine;

public class C_Point : MonoBehaviour
{
    /*
    *   Camera Point Script
    *   These are attached to empty game objects which teleport the camera to the camera needed
    */

    //if Set to True the Camera Wont have Any Movement At all
    public bool LockedCamera = true;


    // if Locked Camera is Set to True Than this Doesnt Matter
    public Vector2 MinAndMaxViewAngle;

    public Vector2 CameraPosition;

    //if this is on then that camera is offline for a set amount of time
   public bool isCameraOffline = false;

    public bool isPlayerLookingAtCamera = false;


 


    /// <summary>
    /// Camera ID for lookup in Database
    /// </summary>
    
    [Unity.Collections.ReadOnly] public int ID = 0;

    [Header("Tools")]
    /// <summary>
    /// Name of Camera
    /// </summary>
    public readonly string Name = "name";

  
    [EditorCools.Button]
    public void LOCKBUTTON()
    {
        if (isCameraOffline == false)
        {


            StartCoroutine(DisableCamera());
        }
    }
    
    [EditorCools.Button]
    public void FingerPrint()
    {
        UI_FingerPrints.instance.FingerPrints(this);
    }


    private void Awake()
    {
        C_Manager.instance.CameraPoints.Add(this);
    }



    private void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.E))
        {
            if (isCameraOffline == false)
            {


                StartCoroutine(DisableCamera());
            }
        }*/
    }


    /// <summary>
    /// Discription of Camera that i want to apear under name
    /// </summary>
    public readonly string Description = "This Needs To Be Filled Out";

    public IEnumerator DisableCamera()
    {

        Debug.Log("Disabled Cameras Waiting");
        yield return new WaitUntil(() => isPlayerLookingAtCamera == false);
        Debug.Log("Disabled Cameras Active");

        isCameraOffline = true;

        yield return new WaitForSeconds(3f);
        Debug.Log("Disabled Cameras Disabled");
        isCameraOffline = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * 4);
    }








}
