using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;
using UnityEngine.UI;

public class JazzMusician : MonoBehaviour {

    [SerializeField] private VRInteractiveItem m_InteractiveItem;
    public AudioSource musicianSource;
    public Text uiText;
    public string musicianName;
    public AudioController audioController;

    public GameController gameController;

    public void Start() {
        uiText.text = musicianName;
    }

    private void OnEnable()
    {
        m_InteractiveItem.OnOver += HandleOver;
        m_InteractiveItem.OnOut += HandleOut;
    }


    private void OnDisable()
    {
        m_InteractiveItem.OnOver -= HandleOver;
        m_InteractiveItem.OnOut -= HandleOut;
    }

    private void HandleOver()
    {
        Debug.Log("Over Musician: " + musicianName);
        gameController.FillSelectionBar(3.0f);      // Fade Audio during this time ???
        musicianSource.Play();
        audioController.TryFadeJazz();
        uiText.enabled = true;
        //audioClip.play
    }

    private void HandleOut()
    {
        audioController.CancelFadeJazz();
        gameController.CancelSelectionBar();
        musicianSource.Pause();
        //audioClip.stop
        //gameController.UnFadeAudio();
        uiText.enabled = false;
    }

}
