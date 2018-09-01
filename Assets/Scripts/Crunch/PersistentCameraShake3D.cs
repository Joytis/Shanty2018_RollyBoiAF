using UnityEngine;

[CreateAssetMenu(
    fileName = "PersistentCameraShake3D", 
    menuName = "Game/PersistentCameraShake3D"
)]
public class PersistentCameraShake3D : ScriptableObject {

    [SerializeField] float timeFromMaxToMin = 1.0f;
    [SerializeField] float maxAngle = 20.0f;
    // Rate at which trauma decreases per second. 
    [SerializeField] float xTimeScale = 1.0f;
    [SerializeField] float yTimeScale = 1.0f;

    public float TimeFromMaxToMin => timeFromMaxToMin;
    public float MaxAngle => maxAngle;
    public float XTimeScale => xTimeScale;
    public float YTimeScale => yTimeScale;
    public float MinimumTrauma {get; set;} = 0f;

    public float Trauma {get; private set;}
    public float Shake => Trauma * Trauma;
    float traumaDrainRate;

    // Use this for initialization
    void OnEnable () => traumaDrainRate = 1f / timeFromMaxToMin;
    public float GetShakeAmnt() => Trauma * Trauma;
    public void RemoveAllTrauma() => Trauma = MinimumTrauma;

    public void UpdateTrauma(float deltaTime) {
        Trauma -= traumaDrainRate * deltaTime;
        Trauma = Mathf.Max(Trauma, MinimumTrauma);
    }

    public void AddTrauma(float amnt) {
        Trauma += amnt;
        Trauma = Mathf.Min(Trauma, 1.0f);
    }
}
