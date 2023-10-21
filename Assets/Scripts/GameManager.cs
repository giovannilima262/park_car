using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
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
    [Header("Foul")]
    [SerializeField]
    private GameObject plateFoul;
    [SerializeField]
    private GameObject foul1;
    [SerializeField]
    private GameObject foul2;
    [SerializeField]
    private GameObject foul3;
    [Header("Next Level")]
    [SerializeField]
    private GameObject plateComplete;
    #endregion

    #region Private Variables
    private int sound;
    private float volume;
    private int lives = 3;
    #endregion

    void Start()
    {
        volume = audioSource.volume;
        sound = PlayerPrefs.GetInt("Sound", 1);
        ActionPause(sound == 0);
    }

    public void OnLevelComplete()
    {
        plateComplete.transform.DOMoveY(0f, 0.5f).SetEase(Ease.OutBounce).OnComplete(() =>
        {
            plateComplete.transform.DOMoveY(-1035f, 0.5f).SetDelay(2f).SetEase(Ease.OutBounce);
        });
    }

    public void OnFoul()
    {
        lives--;
        if (lives == 2)
        {
            foul1.SetActive(true);
        }
        else if (lives == 1)
        {
            foul2.SetActive(true);
        }
        else if (lives == 0)
        {
            foul3.SetActive(true);
        }
        plateFoul.transform.DOMoveY(0f, 0.5f).SetEase(Ease.OutBounce).OnComplete(() =>
        {
            plateFoul.transform.DOMoveY(-1035f, 0.5f).SetDelay(1f).SetEase(Ease.OutBounce);
        });
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
