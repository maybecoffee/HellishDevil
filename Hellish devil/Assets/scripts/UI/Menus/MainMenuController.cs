using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using TMPro;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Slider slider_master, slider_music, slider_sound;
    [SerializeField] private AudioMixerGroup master, music, sound;
    [SerializeField] private TMP_Dropdown quality_dropdown;

    private void Awake()
    {
        List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();

        foreach (var item in QualitySettings.names)
        {
            options.Add(new TMP_Dropdown.OptionData(item));
        }

        quality_dropdown.options = options;
    }
    private void Start()
    {
        if (SettingsManager.Instance.LoadSettings())
        {
            slider_master.value = SettingsManager.Instance.Data.Sound_Master;
            slider_music.value = SettingsManager.Instance.Data.Sound_Music;
            slider_sound.value = SettingsManager.Instance.Data.Sound_Sound;

            quality_dropdown.value = SettingsManager.Instance.Data.Quality;

            QualitySettings.SetQualityLevel(SettingsManager.Instance.Data.Quality);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Save()
    {
        SettingsManager.Instance.Data.Sound_Master = slider_master.value;
        SettingsManager.Instance.Data.Sound_Music = slider_music.value;
        SettingsManager.Instance.Data.Sound_Sound = slider_sound.value;

        SettingsManager.Instance.Data.Quality = quality_dropdown.value;

        QualitySettings.SetQualityLevel(SettingsManager.Instance.Data.Quality);

        SettingsManager.Instance.SaveSettings();
    }
}
