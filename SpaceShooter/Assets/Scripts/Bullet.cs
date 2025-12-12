using NUnit.Framework;
using UnityEngine;
using UnityEngine.AI;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 10;
    [SerializeField] float damage = 10;
    [SerializeField] bool isEnemys = true;
    [SerializeField] ParticleSystem particles;
    [SerializeField] CapsuleCollider coll;
    Vector2 dir = Vector2.zero;
    bool hasHit = false; 
    public void SetSpeed(float newSpeed) {speed = newSpeed;}
    public void SetDamage(float newDamage) {damage = newDamage;}
    public void SetIsEnemys(bool newIsEnemys) {isEnemys = newIsEnemys;}
    public void SetIsDir(Vector2 newDir) {dir = newDir;}



    void FixedUpdate()
    {   
        if (hasHit) return;
        Vector2 deltaDir = dir.normalized * (speed * Time.deltaTime);
        transform.position += new Vector3(deltaDir.x,deltaDir.y,0);
    }

    void OnTriggerEnter(UnityEngine.Collider trigger)
    {
        
        Player player = trigger.gameObject.GetComponent<Player>();
        if (player != null && isEnemys == true)
        {
            player.TakeDamage(damage);
            HitEffect();
        }
        
        Enemy enemy = trigger.gameObject.GetComponent<Enemy>();
        if (enemy != null && isEnemys == false)
        {
            print("Bullet Hit");
            enemy.TakeDamage(damage);
            HitEffect();
        }
    }

    
    void HitEffect()
    {
        hasHit = true;
        coll.enabled = false;

        if (particles != null)
        {
            particles.transform.SetParent(null); 
            particles.Play();

            Destroy(particles.gameObject, particles.main.duration); 
        }

        Destroy(gameObject);
    }

}
