using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;

public class TransitionGate : MonoBehaviour {

    [SerializeField] private VRInteractiveItem m_InteractiveItem;
    public VideoSphere playOverVidSphere;
    public VideoSphere stopOverVidSphere;

    private MeshRenderer playOverVidMesh;
    private MeshRenderer stopOverVidMesh;

    public GameController gameController;

    private void OnEnable()
    {
        playOverVidMesh = playOverVidSphere.GetComponent<MeshRenderer>();
        stopOverVidMesh = stopOverVidSphere.GetComponent<MeshRenderer>();
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
        stopOverVidSphere.StopVideo();
        stopOverVidMesh.enabled = false;

        playOverVidMesh.enabled = true;
        playOverVidSphere.PlayVideo();
    }

    private void HandleOut()
    {
        //playOverSphere.StopVideo();
    }
}
