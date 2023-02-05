using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
  public AudioMixer audioMixer;
  public TMPro.TMP_Dropdown resolutionDropdown;
  Resolution[] resolutions;
  void Start(){
    resolutions=Screen.resolutions;

    resolutionDropdown.ClearOptions();

    List<string> options = new List<string>();
    int currentResInd=0;
    for (int i=0;i<resolutions.Length; i++){
        string option = resolutions[i].width + " x " + resolutions[i].height;
        options.Add(option);
        if (resolutions[i].width==Screen.currentResolution.width && 
        resolutions[i].height==Screen.currentResolution.height){
            currentResInd=i;
        }
    }
    resolutionDropdown.AddOptions(options);
    resolutionDropdown.value=currentResInd;
    resolutionDropdown.RefreshShownValue();
  }
  public void SetVolume(float volume){
    audioMixer.SetFloat("Volume",volume);
  }
  public void SetFullscreen(bool isFS){
    Screen.fullScreen=isFS;
  }
  public void SetResolution (int resolutionIndex){
    Resolution resolution= resolutions[resolutionIndex];
    Screen.SetResolution(resolution.width,resolution.height, Screen.fullScreen);
  }
}