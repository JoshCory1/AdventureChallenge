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
        SetDefaultButtonSprite(selectedSprite, index, false);
        soundFX.OnSoundFXClick();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void OnLoadLevel(string lvl)
    {
        SetDefaultButtonSprite(selectedSprite, 0, true);
        soundFX.OnSoundFXClick();
        SceneManager.LoadScene(lvl);
    }

    void LoadLevel(string lvl)
    {
        SceneManager.LoadScene(lvl);
    }

    private void SetDefaultButtonSprite(Sprite sprite, int index, bool cycle)
    { 
        Image buttonImage;
        if(cycle == true)
        {
            for(int i = 0; i < levelButtons.Length; i++ )
            {
                buttonImage = levelButtons[i].GetComponent<Image>();
                buttonImage.sprite = sprite;
            }
        }
        else
        {
            buttonImage = levelButtons[index].GetComponent<Image>();
            buttonImage.sprite = sprite;
        }
        
        
    }
}
