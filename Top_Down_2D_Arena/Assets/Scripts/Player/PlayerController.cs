using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject bulletSpwaner;
    [SerializeField] private GameObject bulletSpwaner2;
    
    private AudioManager audioManager;

    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float shootingForce = 20f;       
    
    private Rigidbody2D rigidbody2D;
    private Health health;

    public bool isAlive;
    public bool isShooting = false;
    public bool wasShot  = false;
    public Vector2 direction;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        health = GetComponent<Health>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void Update()
    {
        Move();
        Shoot();
    }

    private void Move()
    {
        isAlive = health.isAlive;

        if (isAlive)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            float scaleFactor = 1f;

            direction = new Vector2(horizontal, vertical);            
            rigidbody2D.velocity = direction * movementSpeed;

            Vector2 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

            if (mousePosition.x > transform.position.x)
            {
                transform.localScale = new Vector2(scaleFactor, transform.localScale.y);
            }
            else if (mousePosition.x < transform.position.x)
            {
                transform.localScale = new Vector2(-scaleFactor, transform.localScale.y);
            }
        }
    }

    private void Shoot()
    {
        if (isAlive && Input.GetButtonDown("Fire1"))
        {
            GameObject bullet;

            isShooting = true;

            audioManager.Play("shoot");

            if (!wasShot)
            {
                bullet = Instantiate(bulletPrefab, bulletSpwaner.transform.position, bulletSpwaner.transform.rotation);                
                wasShot = true;
            } 
            else
            {
                bullet = Instantiate(bulletPrefab, bulletSpwaner2.transform.position, bulletSpwaner2.transform.rotation);
                wasShot = false;
            }

            Rigidbody2D bulletRigidbody2D = bullet.GetComponent<Rigidbody2D>();
            bulletRigidbody2D.velocity = shootingForce * Vector2.right * transform.localScale.x;
        }

        isShooting = false;
    }
}
