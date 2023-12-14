using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Rendering;

public class C_Manager : MonoBehaviour
{
    public static C_Manager instance;

    public List<C_Point> CameraPoints = new List<C_Point>();


    public C_Point CameraLocation = null;


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

    private void Start()
    {
        SwapPoints(0);
    }

    private float Speed = 10;

    private void Update()
    {
        
        if(CameraLocation == null)
        {
            return;

        }
        if(!CameraLocation.LockedCamera)
        {
     
            Vector3 rotationValue;
            if (Input.mousePosition.y >= Screen.height * 0.95 && CameraLocation.CameraPosition.x <= CameraLocation.MinAndMaxViewAngle.x)
            {
                rotationValue = new Vector3(0.05f, 0, 0);
                CameraLocation.CameraPosition += new Vector2(rotationValue.x, rotationValue.y);
                transform.eulerAngles = transform.eulerAngles - rotationValue;
            }

            if (Input.mousePosition.y <= Screen.height * 0.05 && CameraLocation.CameraPosition.x >= -CameraLocation.MinAndMaxViewAngle.x)
            {
                rotationValue = new Vector3(-0.05f, 0, 0);
                CameraLocation.CameraPosition += new Vector2(rotationValue.x, rotationValue.y);
                transform.eulerAngles = transform.eulerAngles - rotationValue;
            }

            if (Input.mousePosition.x >= Screen.width * 0.95 && CameraLocation.CameraPosition.y >= -CameraLocation.MinAndMaxViewAngle.y)
            {
                rotationValue = new Vector3(0, -0.05f, 0);
                CameraLocation.CameraPosition += new Vector2(rotationValue.x, rotationValue.y);
                transform.eulerAngles = transform.eulerAngles - rotationValue;
            }

            if (Input.mousePosition.x <= Screen.width * 0.05 && CameraLocation.CameraPosition.y <= CameraLocation.MinAndMaxViewAngle.y)
            {
                rotationValue = new Vector3(0, 0.05f, 0);
                CameraLocation.CameraPosition += new Vector2(rotationValue.x, rotationValue.y);
                transform.eulerAngles = transform.eulerAngles - rotationValue;
            }
        }
    }



    /// <summary>
    /// Change the Position of the Camera To the ID Set
    /// </summary>
    /// <param name="ID"></param>
    public void SwapPoints(int ID)
    {
        //Debug.Log("Swap Point Counted");
        foreach(C_Point p in CameraPoints)
        {
          
            if (!p.isCameraOffline)
            {
                if (p.ID == ID)
                {
                    Camera.main.transform.parent = p.gameObject.transform;
                    Camera.main.transform.position = p.gameObject.transform.position;
                    Camera.main.transform.rotation = p.gameObject.transform.rotation;
                    if(!p.LockedCamera)
                    {
                        transform.eulerAngles = transform.eulerAngles - new Vector3(p.CameraPosition.x, p.CameraPosition.y,0);
                    }

                    p.isPlayerLookingAtCamera = true;
                    CameraLocation = p;
                    UI_FingerPrints.instance.CameraUpdated();
                    foreach(C_Point p2 in CameraPoints)
                    {
                        if(p2.ID != p.ID)
                        {
                            p2.isPlayerLookingAtCamera=false;
                        }
                    }
                }
            }else
            {
                Debug.Log("Camera Offline Cant Switch To it");
            }
            

        }
    }
}
