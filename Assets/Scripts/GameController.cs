using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using VRStandardAssets.Utils;

public class GameController : MonoBehaviour {


    public Transform player;
    public GameObject mainCamera;
    public VideoSphere bandVidSphere;
    public VideoSphere vidSphere1;
    public VideoSphere vidSphere2;

    public Image reticleDot;
    public Image reticleSelection;
    public Image reticleBackground;

    private BlinkEffect blinkEffect;
    private bool canBlink = true;
    private bool cancelSelection = true;

    // Use this for initialization
    void Start () {
        blinkEffect = mainCamera.GetComponent<BlinkEffect>();
        showRecticleDot();

        // Movie Player is weird and needs a late start !!!!
        StartCoroutine(LateStart(0.5f));
    }

    IEnumerator LateStart(float waitTime) {
        yield return new WaitForSeconds(waitTime);
        // init spheres
        bandVidSphere.PlayVideo();
    }

public void showRecticleDot ()
    {
        reticleSelection.enabled = false;
        reticleBackground.enabled = false;
        reticleDot.enabled = true;
    }

    public void CancelSelectionBar()
    {
        cancelSelection = true;
    }


    public void FillSelectionBar()
    {
        Debug.Log("FillSelectionBar");
        reticleSelection.fillAmount = 0f;
        reticleBackground.enabled = true;
        reticleSelection.enabled = true;
        
        reticleDot.enabled = false;
        cancelSelection = false;
        StartCoroutine(FillReticleSelection(0.5f));
    }

    private IEnumerator FillReticleSelection(float selectionWait)
    {
        //Debug.Log("FillReticleSelection");
        float minSel = 0.0f;
        float maxSel = 1.0f;
        float currSel = minSel;

        reticleSelection.fillAmount = minSel;

        while (minSel < maxSel && cancelSelection == false)
        {
            reticleSelection.fillAmount = Mathf.Lerp(minSel, maxSel, currSel);
            currSel += selectionWait * Time.deltaTime;
            yield return null;
        }

        reticleSelection.fillAmount = maxSel;
        if (cancelSelection == false) {
            PlayBlinkEffect();
        } else {
            showRecticleDot();
        }
    }


    public void PlayBlinkEffect()
    {
        Debug.Log("Trying to Blink");
        if (canBlink)
        {
            canBlink = false;   // don't allow any blinking commands while in motion!!
            blinkEffect.enabled = true;
            //blinkEffect.enabled = evt.enable;
            //StartCoroutine(CloseEyes(evt.moveTo, evt.closeTimeSpreader, evt.openTimeSpreader, evt.blinkWait));
            StartCoroutine(CloseEyes(vidSphere2.transform, 1.1f, 6f, 0f));
            // TODO: disable blink effect when not in use ??
        }
    }

    public void movePlayerTo(Transform moveTo) {
        player.position = moveTo.transform.position;
        vidSphere1.StopVideo();
    }


    private IEnumerator CloseEyes(Transform moveTo, float closeTimeSpreader, float openTimeSpreader, float blinkWait)
    {
        Debug.Log("CloseEyes!");
        float minMask = 0.0f;
        float maxMask = 1.3f;
        float currMask = minMask;

        while (currMask < maxMask)
        {
            blinkEffect.maskValue = Mathf.Lerp(minMask, maxMask, currMask);
            currMask += closeTimeSpreader * Time.deltaTime;
            yield return null;
        }

        blinkEffect.maskValue = maxMask;

        //EventController.Instance.Publish(new TeleportPlayerEvent(moveTo));
        //movePlayerTo(moveTo);

        yield return new WaitForSeconds(blinkWait);
        StartCoroutine(OpenEyes(openTimeSpreader));
    }

    private IEnumerator OpenEyes(float openTimeSpreader)
    {
        Debug.Log("OpenEyes!");
        float minMask = 0.0f;
        float maxMask = 1.3f;
        float currMask = maxMask;

        while (currMask > minMask)
        {
            blinkEffect.maskValue = Mathf.Lerp(minMask, maxMask, currMask);
            currMask -= openTimeSpreader * Time.deltaTime;
            yield return null;
        }

        blinkEffect.maskValue = minMask;
        canBlink = true;
    }
}
