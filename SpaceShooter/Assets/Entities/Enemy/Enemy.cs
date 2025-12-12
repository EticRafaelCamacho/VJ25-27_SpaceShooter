using System.Reflection.Emit;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : Damageable
{
    [SerializeField] Rigidbody rb;
    [SerializeField] Vector2 speed;
    [SerializeField] float collisionDamage = 10;

    

    void Start()
    {
        rb.linearVelocity = new Vector3(0,speed.y,0);
    }

    void OnTriggerEnter(UnityEngine.Collider trigger)
    {   
        Player player = trigger.gameObject.GetComponent<Player>();
        if (player != null)
        {
            print("Player Collision");
            player.TakeDamage(collisionDamage);
        }
    } 

    

    new public void DestroySelf()
    {
        Destroy(gameObject); 
    }
}
