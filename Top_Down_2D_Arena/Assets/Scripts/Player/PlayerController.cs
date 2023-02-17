using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject bulletSpwaner;
    [SerializeField] private GameObject bulletSpwaner2;

    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float shootingForce = 20f;       
    
    private Rigidbody2D rigidbody2D;    

    public bool isDead =  false;
    public bool wasShot  = false;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        Shoot();
        //Hurt();
    }

    private void Move()
    {
        if (!isDead)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            float scaleFactor = 1f;

            Vector2 direction = new Vector2(horizontal, vertical);            
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
        if (!isDead && Input.GetButtonDown("Fire1"))
        {
            GameObject bullet;

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
    }

    //private void Hurt()
    //{
    //    if (!isDead)
    //    {
    //        health -= damageTaken;
    //        

    //        if (health <= 0)
    //        {
    //            isDead = true;
    //            StartCoroutine(Die());
    //        }
    //    }
    //}

    //private IEnumerator Die()
    //{
    //    yield return new WaitForSeconds(deathDuration);
    //    Destroy(gameObject);
    //}
}
