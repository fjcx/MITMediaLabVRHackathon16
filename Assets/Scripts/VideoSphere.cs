using UnityEngine;
using System.Collections;

public class VideoSphere : MonoBehaviour {

    private AudioSource audioSource;
    private MoviePlayer moviePlayer;

    private bool isPlaying = false;

    public void Awake()
    {
        moviePlayer = GetComponent<MoviePlayer>();
        audioSource = GetComponent<AudioSource>();      // change when using external audio sources to reference those instead
    }

    // Use this for initialization
    public void Start () {
        

        // play on start --> invoke elsewhere !!!
       // PlayVideo();
    }
	
	public void PlayVideo() {
        if (isPlaying == false) {
            isPlaying = true;
            //audioSource.Play();
            Debug.Log("Starting Video!");
            moviePlayer.StartVideo();
        }
    }

    public void StopVideo()
    {
        if (isPlaying == true)
        {
            isPlaying = false;
            //audioSource.Stop();
            moviePlayer.SetPaused(true);
        }
    }
}
