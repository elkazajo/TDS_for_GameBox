using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private GameObject deathEffectPrefab;    
    [SerializeField] private bool isPlayer = false;
    [SerializeField] private int experienceAmount;

    public float maxHealth = 100;
    public float currentHealth;
    public bool isAlive;
    
    private float flashTime = 0.1f;
    private Color flashColor = Color.red;
    private Color originalColor = Color.white;
    private SpriteRenderer spriteRenderer;
    private GameObject expereiencePrefab;

    private void Start()
    {
        currentHealth = maxHealth;
        isAlive = true;
        spriteRenderer = GetComponent<SpriteRenderer>();
        expereiencePrefab = Resources.Load("Experience") as GameObject;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        spriteRenderer.color = Color.red;

        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            StartCoroutine(FlashSprite());
        }
    }

    private void Die()
    {
        isAlive = false;
        GameObject deathEffect = Instantiate(deathEffectPrefab, transform.position, transform.rotation);
        if (!isPlayer)
        {
            GameObject dropExperience = Instantiate(expereiencePrefab, transform.position, transform.rotation);
            dropExperience.GetComponent<CollectableExperience>().SetExperience(experienceAmount);
            Destroy(gameObject);
        }     

        if (isPlayer)
        {
            WaitForBloodToSplash();
        }
    }

    private IEnumerator FlashSprite()
    {             
        spriteRenderer.color = flashColor;        
        yield return new WaitForSeconds(flashTime);        
        spriteRenderer.color = originalColor;
    }

    private IEnumerator WaitForBloodToSplash()
    {
        yield return new WaitForSeconds(1);
        Time.timeScale = 0;
        Destroy(gameObject);
    }
}
