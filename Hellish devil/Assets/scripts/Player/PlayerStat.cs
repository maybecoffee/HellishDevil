using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStat", menuName = "MyAssets/Create PlayerStat")]
public class PlayerStat : ScriptableObject
{
    public PlayerStatsType Type;
    public float Value;
    public float maxValue;

    public void AddValue(float value)
    {
        Value += value;
        if(Value > maxValue)
        {
            Value = maxValue;
        }

        if (Value < 0)
        {
            Value = 0;
        }

        FindObjectOfType<EventManager>().OnStatChanged.Invoke();
    }
}