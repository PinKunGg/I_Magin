using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{

    public AudioMixer audioMixer;

    public void SetVolune (float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void SetGraphic(int quanlityIndex)
    {
        QualitySettings.SetQualityLevel(quanlityIndex);
    }
}
