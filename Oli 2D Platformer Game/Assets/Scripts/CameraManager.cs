using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraManager : MonoBehaviour
{
    // Start is called before the first frame update
    ArrayList cameraList;
    [SerializeField] GameObject player;

   // private static CameraManager instance;
    void Start()
    {

   /*     if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);*/

        cameraList = new ArrayList();

        foreach(Transform child in transform)
        {
            child.GetComponent<Camera>().gameObject.SetActive(false);
            cameraList.Add(child);
        }

        Transform cam = cameraList[0] as Transform;
        cam.GetComponent<Camera>().gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Transform camera in cameraList)
        {
            Camera cameraComp = camera.GetComponent<Camera>();

            if (player != null)
            {
                Vector3 cameraView = cameraComp.WorldToViewportPoint(player.transform.position);
                //  Debug.Log(cameraView);
                if (IsBetween(cameraView.x, 0, 1) && IsBetween(cameraView.y, 0, 1) && cameraView.z > 0)
                {
                    cameraComp.gameObject.SetActive(true);
                }
                else
                {
                    cameraComp.gameObject.SetActive(false);
                }
            }
        }
    }

    bool IsBetween(double testValue, double bound1, double bound2)
    {
        return (testValue >= Math.Min(bound1, bound2) && testValue <= Math.Max(bound1, bound2));
    }
}
