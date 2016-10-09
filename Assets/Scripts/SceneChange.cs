using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;

public class SceneChange : MonoBehaviour {

    [SerializeField]
    private VRInteractiveItem m_InteractiveItem;
    private bool isReadyForTransit = false;
    public GameController gameController;

    public void Start()
    {
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
        gameController.PlayBlinkEffect();
    }

    private void HandleOut()
    {
        gameController.CancelBlinkTransit();
    }
}
