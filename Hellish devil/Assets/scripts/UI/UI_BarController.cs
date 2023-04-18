using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))] //запрос на компнонент, если его нет, то этот скрипт даже не добавится.
public class UI_BarController : MonoBehaviour
{
    public PlayerStatsType Type;
    private Slider slider;

    private void Start()
    {
        FindObjectOfType<EventManager>().OnStatChanged.AddListener(RedrawUI);

        slider = this.GetComponent<Slider>();
        RedrawUI();
        
    }

   private void RedrawUI()
    {
        PlayerStat returnedStat = FindObjectOfType<Player>().GetPlayerStat(Type);

        if(returnedStat != null)
        {
            slider.maxValue = returnedStat.maxValue;
            slider.value = returnedStat.Value;
        }

        else
        {
            Debug.LogError("CANT_FIND_STAT");
            Application.Quit();
        }
    }
}
