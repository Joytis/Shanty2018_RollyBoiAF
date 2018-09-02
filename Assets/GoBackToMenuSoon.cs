using UnityEngine;
using System.Collections;

public class GoBackToMenuSoon : MonoBehaviour {

    private IEnumerable coroutine;

    public IEnumerable CreditsCoroutine(GameObject obj)
    {
        Debug.Log("Started Coroutine");
        yield return new WaitForSeconds(3f);
        obj.SetActive(true);
        gameObject.SetActive(false);
        Debug.Log("Showing Menu");
    }
	
    public void StartGoback(GameObject obj)
    {
        StartCoroutine("CreditsCoroutine", obj);
    }
}
