using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialStateMachine : MonoBehaviour {

    [System.Serializable]
    public struct ScreenInfo
    {
        public float timeToShow;
        public float pause;
        public GameObject messageToShow;
    }
    [SerializeField] Transform screenDisplayerHandle;
    [SerializeField] List<ScreenInfo> infoScreens;
    [SerializeField] List<ScreenInfo> finalScreens;
    [SerializeField] List<MonoBehaviour> _disabledOnStart = new List<MonoBehaviour>();

    IEnumerator PlayScreens(List<ScreenInfo> screens)
    {
        // Display all info screens
        foreach(var screen in screens)
        {
            var newScreen = GameObject.Instantiate(screen.messageToShow, screenDisplayerHandle);
            yield return new WaitForSeconds(screen.timeToShow);
            Destroy(newScreen);
            yield return new WaitForSeconds(screen.pause);
        }
    }

	// Use this for initialization
	public IEnumerator StartTheThing()
    {
        // Disable components on start
		foreach(var component in _disabledOnStart) {
            component.enabled = false;
        }

        // Wait a bit. 
        yield return new WaitForSeconds(1f);
        // Display all info screens
        yield return PlayScreens(infoScreens);

        // Enable all components after screen info is done. 
        foreach(var component in _disabledOnStart) {
            component.enabled = true;
        }

        yield return PlayScreens(finalScreens);
	}
}
