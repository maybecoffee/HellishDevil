using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Player CurrentPlayer;
    public KeyCode UseKey;
    public float UseDistance = 1;

    virtual public void Start()
    {
        CurrentPlayer = FindObjectOfType<Player>();
    }

    virtual public void Update()
    {
        if (Input.GetKeyDown(UseKey))
        {
            if (Vector3.Distance(CurrentPlayer.transform.position, this.gameObject.transform.position) < UseDistance)
            {
                Use();
            }
        }
    }

    virtual public void Use() // ïåðåçàïèñü â íàñëåäóåìûõ ñêðèïòàõ
    {
        print("ÂÛ ÄÎÏÓÑÒÈËÈ ÈÑÏÎËÜÇÎÂÀÍÈÅ ÄÎÐÎÃÎÑÒÎÅÙÅÃÎ ÎÌÁÓÄÈÐÎÂÀÍÈß " + this.name + "!");
    }

}
