using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZone : MonoBehaviour
{
    public CameraInfo zoneinfo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Player>())
        {
            CameraController camera = FindObjectOfType<CameraController>();

            camera.info = zoneinfo;
        }
    }
}
