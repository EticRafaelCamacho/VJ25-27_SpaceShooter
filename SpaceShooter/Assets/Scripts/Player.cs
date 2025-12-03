using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] Bullet bullet;
    [SerializeField] float fireRate = 1;
    [SerializeField] float speed = 1;
    Vector3 worldTargetDestiantion;
    bool isDragging = false;
    
    void Start()
    {
        InvokeRepeating("Shoot",0,fireRate);
    }


    void Update()
    {
        Movement();
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

    void Shoot()
    {
        Bullet newbullet = Instantiate(bullet, transform.position, Quaternion.identity);
        newbullet.speed = 15;
        newbullet.dir = Vector2.up;
        
    }
    bool IsMouseInsideScreen()
    {
        return Input.mousePosition.x >= 0 && Input.mousePosition.y >= 0 && Input.mousePosition.x <= Screen.width && Input.mousePosition.y <= Screen.height;
    }
}
