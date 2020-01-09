using UnityEngine;

public class ParticleDestroyer : MonoBehaviour
{
    [SerializeField]
    private float timeLeft = 2.0f;

    void Update()
    {
        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0.0f)
            Destroy(this.gameObject);
    }
}
