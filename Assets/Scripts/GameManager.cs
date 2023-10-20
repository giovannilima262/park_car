using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    #region Inspector Variables
    [Header("Audio Source")]
    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private GameObject buttonSoundOn;

    [SerializeField]
    private GameObject buttonSoundOff;
    #endregion

    #region Private Variables
    private int sound;
    private float volume;
    #endregion

    void Start()
    {
        volume = audioSource.volume;
        sound = PlayerPrefs.GetInt("Sound", 1);
        ActionPause(sound == 0);
    }

    public void OnClickSoundOn()
    {
        ActionPause(false);
    }

    public void OnClickSoundOff()
    {
        ActionPause(true);
    }

    private void ActionPause(bool value)
    {
        int valueSound = value ? 0 : 1;
        buttonSoundOn.SetActive(!value);
        buttonSoundOff.SetActive(value);
        if (value)
        {
            audioSource.volume = 0;
        }
        else
        {
            audioSource.volume = volume;
        }
        PlayerPrefs.SetInt("Sound", valueSound);
    }

}
