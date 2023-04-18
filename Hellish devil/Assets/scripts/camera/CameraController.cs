using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera cam;
    public Transform primaryTarget;
    public CameraInfo info;
    
    
    void Start()
    {
        if(this.GetComponent<Camera>())
        {
            cam = this.GetComponent<Camera>();
        }
        else
        {
            Debug.LogError("NO_CAMERA_FOUND");
            Application.Quit();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 newPos = primaryTarget.position;
        newPos.z = info.camZoom;
        newPos.y += info.yOfSet;
        newPos.x += info.xOfSet;

        if(info.secondaryTarget != null)
        {
            Vector3 targetOffset = Vector3.Lerp(primaryTarget.position, info.secondaryTarget.position, 0.5f);
            targetOffset.z = info.camZoom;
            Vector3 finalOffset = targetOffset - primaryTarget.transform.position;
            newPos += finalOffset;

            float distantion = Vector3.Distance(primaryTarget.position, info.secondaryTarget.position);

            newPos.z = Mathf.Clamp(-distantion, info.minZoom, info.maxZoom);
        }

            cam.transform.position = Vector3.Lerp(cam.transform.position, newPos, Time.fixedDeltaTime * info.camSpeed);

        
    }
}

[System.Serializable]
public struct CameraInfo
{

    public Transform secondaryTarget;

    public float camZoom, minZoom, maxZoom;

    public float yOfSet;
    public float xOfSet;

    public float camSpeed;
}