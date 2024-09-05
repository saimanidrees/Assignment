using GameData.MyScripts;
using UnityEngine;
public class SoundController : MonoBehaviour
{
    public static SoundController Instance;
    private void Awake()
    {
        if (Instance != null)
            return;
        Instance = this;
    }
    [SerializeField] private AudioClip btnClickSound, gameCompleteSound, correctSelectionSound, wrongSelectionSound;
    [SerializeField] private AudioSource soundAudioSource;
    private static bool IsSoundOn()
    {
        return PlayerPrefs.GetInt(Constants.SoundString, 1) != 0;
    }
    public void PlayBtnClickSound()
    {
        if (!IsSoundOn())
            return;
        soundAudioSource.clip = btnClickSound;
        soundAudioSource.Play ();
    }
    public void PlayCorrectSelectionSound()
    {
        if (!IsSoundOn())
            return;
        soundAudioSource.clip = correctSelectionSound;
        soundAudioSource.Play ();
    }
    public void PlayWrongSelectionSound()
    {
        if (!IsSoundOn())
            return;
        soundAudioSource.clip = wrongSelectionSound;
        soundAudioSource.Play ();
    }
    public void PlayGameCompleteSound()
    {
        if (!IsSoundOn())
            return;
        soundAudioSource.clip = gameCompleteSound;
        soundAudioSource.Play();
    }
}