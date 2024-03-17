using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelManager : MonoBehaviour
{
    [Header("SFX")]
    [SerializeField] public float sFXVolume = 0.8f;
    [SerializeField] public AudioClip clickSFX;
    SoundFX soundFX;
    
    [Header("Buttons")]
    [SerializeField] GameObject [] levelButtons;

    [Header("Button Colors")]
    [SerializeField] Sprite selectedSprite;

    void Awake() 
    {
        soundFX = FindObjectOfType<SoundFX>();
    }


    public void OnReplayLevel(int index)
    {
        StartCoroutine(ReplayLevel());
    }

    IEnumerator ReplayLevel()
    {
        soundFX.OnSoundFXClick();
        yield return new WaitForSeconds(.3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnLoadLevel(string lvl)
    {
        StartCoroutine(LoadLevel(lvl));
    }

    IEnumerator LoadLevel(string lvl)
    {
        soundFX.OnSoundFXClick();
        yield return new WaitForSeconds(.3f);
        SceneManager.LoadScene(lvl);
    }
}
