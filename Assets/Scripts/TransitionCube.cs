using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;

public class TransitionCube : MonoBehaviour {

    [SerializeField] private VRInteractiveItem m_InteractiveItem;
    [SerializeField] private VideoSphere videoSphere;
    public GameController gameController;

    private void OnEnable()
    {
        m_InteractiveItem.OnDoubleClick += HandleDoubleClick;
        m_InteractiveItem.OnOver += HandleOver;
        m_InteractiveItem.OnOut += HandleOut;
    }


    private void OnDisable()
    {
        m_InteractiveItem.OnDoubleClick -= HandleDoubleClick;
        m_InteractiveItem.OnOver -= HandleOver;
        m_InteractiveItem.OnOut -= HandleOut;
    }

    private void HandleDoubleClick()
    {

    }

    private void HandleOver()
    {
        videoSphere.PlayVideo();
        gameController.FillSelectionBar();
    }

    private void HandleOut()
    {
        videoSphere.StopVideo();
        gameController.CancelSelectionBar();
    }
}
