using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public SettingData Data;

    public void SaveSettings()
    {
        string jsontext = JsonUtility.ToJson(Data);

        using (var file = File.Create($"Assets/_saves/Settings.json"))
        {
            StreamWriter writer = new StreamWriter(file);

            writer.WriteLine(jsontext);
            writer.Close();
        }
    }

    public bool LoadSettings()
    {
        string jsontext;

        if (!File.Exists($"Assets/_saves/Settings.json"))
        {
            Debug.LogError("[ERROR] Settings file not found");
            return false;

        }

        using (var file = File.Open($"Assets/_saves/Settings.json", FileMode.Open))
        {
            StreamReader reader = new StreamReader(file);

            jsontext = reader.ReadLine();

            SettingData newData = JsonUtility.FromJson<SettingData>(jsontext);
            Data = newData;
            Debug.Log(newData.Sound_Master);
        }

        return true;
    }
}


[System.Serializable]
public class SettingData
{
    public float Sound_Master = 1;
    public float Sound_Music = 1;
    public float Sound_Sound = 1;

    public int Quality = 2;
}
