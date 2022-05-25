using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public List<AudioSource> sounds;
    public AudioSource music;
    bool state = true;
    public GameObject tick;
    public GameObject settings;
    public Slider slider;
    public MonsterPrefabStuff monster;
    private Vector3 startScale;

    void Start()
    {
        startScale = new Vector3(1f,1f,1f);
        settings.GetComponent<Transform>().localScale = Vector3.zero;
    }

    public void openSettings()
    {
        settings.SetActive(true);
        LeanTween.scale(settings, startScale, 0.2f);
    }

    public void closeSettings()
    {
        LeanTween.scale(settings, Vector2.zero, 0.2f).setOnComplete(deactivate);
    }

    public void deactivate()
    {
        settings.SetActive(false);
    }

    



    public void toggleSounds()
    {
        if (state)
        {
            monster.sounds = false;
            tick.SetActive(false);
            foreach (var sound in sounds)
            {
                sound.mute = true;
                state = false;
            }
        }
        else
        {
            monster.sounds = true;
            tick.SetActive(true);
            foreach (var sound in sounds)
            {
                sound.mute = false;
                state = true;
            }
        }
    }

    public void changeMusic()
    {
        music.volume = slider.value;
    }
}
