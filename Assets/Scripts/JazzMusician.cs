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

    public GameObject trailSphere1;
    public GameObject trailSphere2;
    public GameObject trailSphere3;
    public GameObject trailSphere4;
    public GameObject transitSphere;

    public GameController gameController;

    bool isShowSphereCancelled = true;

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
        ShowTransitSpheres();
        //audioClip.play
    }

    public void ShowTransitSpheres()
    {
        isShowSphereCancelled = false;
        StartCoroutine(ShowAllTransitSpheres());
    }

    private IEnumerator ShowAllTransitSpheres()
    {
        while(isShowSphereCancelled == false)
        {
            if (trailSphere1.activeSelf == false)
            {
                trailSphere1.SetActive(true);
                yield return new WaitForSeconds(1f);
            }
            else if (trailSphere2.activeSelf == false)
            {
                trailSphere2.SetActive(true);
                yield return new WaitForSeconds(1f);
            }
            else if (trailSphere3.activeSelf == false)
            {
                trailSphere3.SetActive(true);
                yield return new WaitForSeconds(1f);
            }
            else if (trailSphere4.activeSelf == false)
            {
                trailSphere4.SetActive(true);
                yield return new WaitForSeconds(0f);
            }
            else if (transitSphere.activeSelf == false)
            {
                transitSphere.SetActive(true);
                yield return new WaitForSeconds(1f);
            }
            else
            {
                isShowSphereCancelled = true;
            }
        }
        
        yield return null;
    }

    private void HandleOut()
    {
        audioController.CancelFadeJazz();
        gameController.CancelSelectionBar();
        musicianSource.Pause();
        isShowSphereCancelled = true;
        //audioClip.stop
        //gameController.UnFadeAudio();
        uiText.enabled = false;
    }

}
