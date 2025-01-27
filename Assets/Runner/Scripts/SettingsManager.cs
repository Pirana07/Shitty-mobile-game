using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Import this namespace for the Image class

public class SettingsManager : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private Image soundButtonImage; // Ensure Image is from UnityEngine.UI
    [SerializeField] private Sprite optionOnSprite;
    [SerializeField] private Sprite optionOffSprite;

    [Header("Settings")]
    private bool soundsState = true;


     void Awake() {

        soundsState = PlayerPrefs.GetInt("sounds", 1) == 1;
    }
    void Start()
    {
        Setup();
    }

    public void ChangeSoundState()
    {
        if (soundsState)
        {
           EnableSound();

        }
        else
        {
            DisableSound();
        }

        soundsState = !soundsState;
         PlayerPrefs.GetInt("sounds", soundsState ? 1 : 0);
    }

    private void Setup()
    {
        if (soundsState)
            DisableSound();
        else
            EnableSound();
    }

    private void DisableSound()
    {
        if (audioManager != null)
            audioManager.DisableSound();

        if (soundButtonImage != null)
            soundButtonImage.sprite = optionOffSprite;
    }

    private void EnableSound()
    {
        if (audioManager != null)
            audioManager.EnableSound();

        if (soundButtonImage != null)
            soundButtonImage.sprite = optionOnSprite;
    }
}
