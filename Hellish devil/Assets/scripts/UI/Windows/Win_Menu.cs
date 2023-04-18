using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win_Menu : UIwindow
{
    public override void Update()
    {
        base.Update();

    }

    public override void HideWindow()
    {
        base.HideWindow();

        Time.timeScale = 1;
    }

    public override void ShowWindow()
    {
        base.ShowWindow();

        Time.timeScale = 0;
    }
}
