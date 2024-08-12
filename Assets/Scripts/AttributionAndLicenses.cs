using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributionAndLicenses : MonoBehaviour
{
    [SerializeField] Canvas levelCanvas;


    private void Start() 
    {
        gameObject.SetActive(false);    
    }
    public void OnShowAttribute()
    {
        levelCanvas.gameObject.SetActive(false);
        gameObject.SetActive(true);
    }

    public void OnHideAttribute()
    {
        gameObject.SetActive(false);
        levelCanvas.gameObject.SetActive(true);
    }
}
