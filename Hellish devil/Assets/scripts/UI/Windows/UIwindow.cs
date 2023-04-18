using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIwindow : MonoBehaviour
{
    public GameObject Content;
    public bool isActive;

    public KeyCode ShowKey = KeyCode.None;

    virtual public void Update()
    {
        if(Input.GetKeyDown(ShowKey))
        {
            if(isActive == true)
            {
                HideWindow();
            }
            else
            {
                ShowWindow();
            }
        }
    }

    public virtual void ShowWindow()
    {
        Content.SetActive(true);
        isActive = true;
    }

    public virtual void HideWindow()
    {
        Content.SetActive(false);
        isActive = false;
    }
}
