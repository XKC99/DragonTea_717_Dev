using UnityEngine;

public class TargetTrigger : MonoBehaviour
{
    public TimerTrigger timerTrigger;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            timerTrigger.PlayerReachedTarget();
        }
    }
}

