using UnityEngine;
using UnityEngine.UIElements;

public class Player : Damageable
{

    [SerializeField] Bullet bullet;
    [SerializeField] float fireRate = 100;
    [SerializeField] float speed = 1;
    [SerializeField] float bulletDamage = 1;
    [SerializeField] float bulletSpeed = 15;
    Vector3 worldTargetDestiantion;
    float shootCooldown = 0f;

    void Update()
    {
        Movement();
        HandleShooting();
    }

    void FixedUpdate()
    {
       
        Vector3 positionInBetween = Vector2.Lerp(transform.position, worldTargetDestiantion, speed*Time.deltaTime);
        transform.position = new Vector3(positionInBetween.x,positionInBetween.y,15);
    }

    void Movement()
    {
        if (Input.GetMouseButton(0))
        {

            Vector3 mousePos = Input.mousePosition;

            mousePos.x = Mathf.Clamp(mousePos.x, 0, Screen.width);
            mousePos.y = Mathf.Clamp(mousePos.y, 0, Screen.height);

            mousePos.z = 15f;

            worldTargetDestiantion = Camera.main.ScreenToWorldPoint(mousePos);
        }
        
    }

    void HandleShooting()
    {
        shootCooldown -= Time.deltaTime * fireRate;

        if (shootCooldown <= 0f)
        {
            Shoot();
            shootCooldown = 1;
        }
    }

    void Shoot()
    {
        Bullet newbullet = Instantiate(bullet, transform.position, Quaternion.identity);
        newbullet.SetDamage(bulletDamage);
        newbullet.SetSpeed(bulletSpeed);
        newbullet.SetIsDir(Vector2.up);
        newbullet.SetIsEnemys(false);
        
    }
    new public void DestroySelf()
    {
        Destroy(gameObject); 
    }

    #region Stat Increasers
    public void IncreaseBulletDamage(float amount)
    {
        bulletDamage += amount;
    }

    public void IncreaseBulletSpeed(float amount)
    {
        bulletSpeed += amount;
    }

    public void IncreaseSpeed(float amount)
    {
        speed += amount;
    }

    public void IncreaseFireRate(float amount)
    {
        fireRate += amount;
    }
    #endregion
}

