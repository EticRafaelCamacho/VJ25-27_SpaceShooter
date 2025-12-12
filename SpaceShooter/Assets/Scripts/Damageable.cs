using NUnit.Framework.Constraints;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField] float hp = 100;
    [SerializeField] Animator anim;
    [SerializeField]  ParticleSystem deathParticles;
   
    bool dead = false;

    float destroyWaitTime = 0;
    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void TakeDamage(float damage)
    {
        print("Took Damage");
        hp -= damage;
        if (hp <= 0)
        {
            if (dead != true)
            {
                dead = true;
                DestroySelf();
            }
            
        }
    }
    
    public void DestroySelf()
    {
        AnimationClip deathAnim = GetAnimationClip(anim, "Death");
        if (anim != null)
        {
            anim.SetBool("Dead", dead);
            destroyWaitTime += deathAnim.length;
        }
        if (deathParticles != null)
        {
            destroyWaitTime += deathParticles.main.duration;
        }

        Destroy(gameObject,destroyWaitTime);

    }

    AnimationClip GetAnimationClip(Animator animator, string clipName)
    {
    foreach (var clip in animator.runtimeAnimatorController.animationClips)
    {
        if (clip.name == clipName)
            return clip;
    }
    return null;
    }


    public void PlayDeathParticles()
    {
        deathParticles.Play();
    }
}