using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseWhenTouchedBy : MonoBehaviour {


    public string layer;
    public float loseAfterCollisionAndTime = 1f;
    public GameWinLossController _winLossController;

    IEnumerable GameOverEventually(float timeframe)
    {
        yield return new WaitForSeconds(timeframe);
        _winLossController.GameOver();
    }

    IEnumerable OnCollisionEnter(Collision coll)
    {
        if(coll.gameObject.layer == LayerMask.NameToLayer(layer))
        {
            yield return GameOverEventually(loseAfterCollisionAndTime);
        }
    }
}
