using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// create this required component....
[RequireComponent (typeof (AudioSource))]

public class AudioPeer : MonoBehaviour {

	// need to instantiate an audio source and array of samples to store the fft data.
    public AudioSource _audioSource;
    //public AudioClip a0;
    //public AudioClip a1;
    public AudioClip[] ac;
	// NOTE: make this a 'static' float so we can access it from any other script.
	public static float[] spectrumData = new float[512];



	// Use this for initialization
	void Start () {

        _audioSource = GetComponent<AudioSource> ();

        _audioSource.clip = ac[0];
        _audioSource.Play();
    }

   
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.S))
        {
            _audioSource.Stop();
            //_audioSource.clip = ac[1];
            if(_audioSource.clip == ac[0])
            {
                _audioSource.clip = ac[1];
            }
            else if(_audioSource.clip == ac[1])
            {
                _audioSource.clip = ac[2];
            }
            else if(_audioSource.clip == ac[2])
            {
                _audioSource.clip = ac[0];
            }
            _audioSource.Play();
        }
        GetSpectrumAudioSource ();
       // _audioSource.Play();
	}


	void GetSpectrumAudioSource()
	{
		// this method computes the fft of the audio data, and then populates spectrumData with the spectrum data.
		_audioSource.GetSpectrumData (spectrumData, 0, FFTWindow.Hanning);
	}
}


