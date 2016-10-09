using UnityEngine;
using System.Collections;


public class AudioController : MonoBehaviour {

    public AudioSource jazzSource;
    public float jazzCurrentVolume;
    public bool isVolFaded = false;
    public bool isFading = false;
    public float fadeInterval = 0.5f;

    public void Start() {
        jazzCurrentVolume = jazzSource.volume;
    }

    public void TryFadeJazz()
    {
        if (isVolFaded == false && isFading == false) {
            isFading = true;
            isVolFaded = true;
            Debug.Log("FadeJazz");
            jazzCurrentVolume = jazzSource.volume;
            //jazzSource.volume = jazzSource.volume * 0.1f;
            StartCoroutine(FadeJazzSlowly(fadeInterval));     // NOTE: this should be the same as the reticle filling time !!!!
        }
    }

    private IEnumerator FadeJazzSlowly(float fadeInterval)
    {
        Debug.Log("FillReticleSelection");
        float maxVol = jazzCurrentVolume;
        float minVol = jazzCurrentVolume * 0.1f;
        float currvol = maxVol;

        jazzSource.volume = maxVol;

        while (jazzSource.volume > minVol && isFading == true) {
            jazzSource.volume = Mathf.Lerp(maxVol, minVol, currvol);
            currvol -= fadeInterval * Time.deltaTime;
            yield return null;
        }
    }

    public void CancelFadeJazz()
    {
        isFading = false;
        jazzSource.volume = jazzCurrentVolume;
        isVolFaded = false;
    }


}
