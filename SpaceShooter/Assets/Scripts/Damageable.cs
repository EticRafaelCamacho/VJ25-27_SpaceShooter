using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField] float hp = 100;
    public void TakeDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            DestroySelf();
        }
    }

    public void DestroySelf()
    {
        Destroy(gameObject); 
    }
}
