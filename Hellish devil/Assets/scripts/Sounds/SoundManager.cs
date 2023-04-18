using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField] [Range(0, 1f)] private float volume;

    private void Awake() { Instance = this; }

    public void PlaySound(AudioClip clip)
    {
        AudioSource Sourse = this.gameObject.AddComponent<AudioSource>();
        Sourse.clip = clip;
        Sourse.Play();
        Sourse.loop = false;
        Sourse.volume = volume;
        Sourse.pitch = Random.Range(0.5f, 1.5f);
    }
}
