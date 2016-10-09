using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;
using UnityEngine.UI;

public class JazzMusician : MonoBehaviour {

    [SerializeField] private VRInteractiveItem m_InteractiveItem;
    public AudioClip audioClip;
    public Text uiText;
    public string musicianName;
    public AudioSource jazzSource;
    public float currentVolume;
    public bool atLowerVol = false;
    public bool cancelFade = false;


    public GameController gameController;

    public void Start() {
        uiText.text = musicianName;
        currentVolume = jazzSource.volume;
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
        //gameController.FillSelectionBar();      // Fade Audio during this time ???
        FadeJazz();
        uiText.enabled = true;
        //audioClip.play

    }

    public void FadeJazz()
    {
        if (atLowerVol == false)
        {
            Debug.Log("FadeJazz");
            currentVolume = jazzSource.volume;
            cancelFade = false;
            jazzSource.volume = jazzSource.volume * 0.1f;
           // StartCoroutine(FadeJazzSlowly(0.5f));     // NOTE: this should be the same as the reticle filling time !!!!
        }
    }

    private IEnumerator FadeJazzSlowly(float selectionWait)
    {
        Debug.Log("FillReticleSelection");
        float maxVol = currentVolume;
        float minVol = currentVolume * 0.1f;
        float currvol = maxVol;

        jazzSource.volume = maxVol;

        while (minVol < currvol && cancelFade == false)
        {
            jazzSource.volume = Mathf.Lerp(maxVol, minVol, currvol);
            currvol -= selectionWait * Time.deltaTime;
            yield return null;
        }
    }



    private void HandleOut()
    {
        jazzSource.volume = currentVolume;
        //gameController.CancelSelectionBar();
        //audioClip.stop
        //gameController.UnFadeAudio();
        uiText.enabled = false;
    }
}
