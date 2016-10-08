using UnityEngine;
using System.Collections;

public class VideoSphere : MonoBehaviour {

    private AudioSource audioSource;
    private MoviePlayer moviePlayer;

    // Use this for initialization
    public void Start () {
        moviePlayer = GetComponent<MoviePlayer>();
        audioSource = GetComponent<AudioSource>();      // change when using external audio sources to reference those instead
    }
	
	public void PlayVideo() {
        //audioSource.Play();
        moviePlayer.StartVideo();
    }

    public void StopVideo()
    {
        //audioSource.Stop();
        moviePlayer.SetPaused(true);
    }
}
