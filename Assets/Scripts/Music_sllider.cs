using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class music_sllider : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private Slider slider;
    [SerializeField] private string saveVolumeKey;

    [SerializeField] private string sliderTag;

    [SerializeField] private float volume;

    private void Awake() {
        GameObject sliderObj = GameObject.FindWithTag(this.sliderTag);
        if(PlayerPrefs.HasKey(this.saveVolumeKey)){
            this.volume = PlayerPrefs.GetFloat(this.saveVolumeKey);
            this._audio.volume = this.volume;
        }
        if(sliderObj != null){
            this.slider = sliderObj.GetComponent<Slider>();
            this.volume = slider.value;
        }
        else{
            this.volume = 0.5f;
            PlayerPrefs.SetFloat(this.saveVolumeKey, this.volume);
            this._audio.volume = this.volume;
        }
    }

    private void LateUpdate() {
        GameObject sliderObj = GameObject.FindWithTag(this.sliderTag);
            if(sliderObj != null){
                this.slider = sliderObj.GetComponent<Slider>();
                this.volume = slider.value;

            if(this._audio.volume != this.volume){
                PlayerPrefs.SetFloat(this.saveVolumeKey, this.volume);
            }
        }
        this._audio.volume = this.volume;

    }


}
