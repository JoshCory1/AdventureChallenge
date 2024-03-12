using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
void Awake() 
{
  int numSFX = FindObjectsOfType<SFX>().Length;
  if(numSFX > 1)
  {
      Destroy(gameObject);
  }
  else
  {
    DontDestroyOnLoad(gameObject);
  }
  
}
}
