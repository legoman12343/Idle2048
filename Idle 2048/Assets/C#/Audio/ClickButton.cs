using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickButton : MonoBehaviour
{
    public AudioSource sound;
    public void onClick()
    {
        sound.Play();
    }
}
