using UnityEngine;
using UnityEngine.AI;

public class Bullet : MonoBehaviour
{
    [SerializeField] public float speed = 10;
    [SerializeField] public float damage = 1;
    [SerializeField] public bool isEnemy = true;
    public Vector2 dir = Vector2.zero;

    void Start()
    {
        
    }

    void FixedUpdate()
    {   
        Vector2 deltaDir = dir.normalized * (speed * Time.deltaTime);
        transform.position += new Vector3(deltaDir.x,deltaDir.y,0);
    }

    void OnTriggerEnter(UnityEngine.Collider other)
    {
        print(other.transform.name);
    }
    void OnCollisionEnter(Collision collision)
    {
        
    }
}
