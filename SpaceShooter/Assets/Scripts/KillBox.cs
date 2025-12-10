using UnityEngine;

public class KillBox : MonoBehaviour
{
    void OnTriggerEnter(UnityEngine.Collider trigger)
    {
        Destroy(trigger.gameObject);
    }
}
