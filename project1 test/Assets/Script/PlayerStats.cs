using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int health = 6; 
    public int lives = 3;
    private float flickerTime = 0f;
    public float flickerDuration = 0.1f;
    private SpriteRenderer spriteRenderer;
    public bool isImmune = false;
    public bool isImmuneGranted = false;
    private float immunityTime = 0f;
    public float immunityDuration = 1.5f;
    public float grantedImmunityDuration = 3.5f;
    public int coinsCollected = 0;

    public Image healthBar;
    public Image CurseBar;
 

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isImmune == true)
        {
            SpriteFlicker();
            immunityTime = immunityTime + Time.deltaTime;
            if (immunityTime >= immunityDuration)
            {
                this.isImmune = false;
                this.spriteRenderer.enabled = true;
            }
        }

        if (this.isImmuneGranted == true)
        {
            immunityTime = immunityTime + Time.deltaTime;
            if (immunityTime >= grantedImmunityDuration)
            {
                this.isImmune = false;
                this.spriteRenderer.enabled = true;
            }
        }

        healthBar.fillAmount = this.health/8f;
    }
    void SpriteFlicker()
    {
        if (this.flickerTime < this.flickerDuration)
        {
            this.flickerTime = this.flickerTime + Time.deltaTime; ;
        }
        else if (this.flickerTime >= this.flickerDuration)
        {
            spriteRenderer.enabled = !(spriteRenderer.enabled);
            this.flickerTime = 0;
        }
    }
    public void TakeDamage(int damage)
    {
        if (this.isImmune == false)
        {
            this.health = this.health - damage;
            if (this.health < 0)
            {
                this.health = 0;
            }
            if (this.lives > 0 && this.health == 0)
            {
                FindObjectOfType<LevelManager>().RespawnPlayer();
                this.health = 6;
                this.lives--;
            }
            else if (this.lives == 0 && this.health == 0)
            {
                Debug.Log("GameOver");
                
                Destroy(this.gameObject);
            }
            Debug.Log("Player Health:" + this.health.ToString());
            Debug.Log("Player Lives:" + this.lives.ToString());

        }
        PlayHitReaction();
    }
    public void PlayHitReaction()
    {
        this.isImmune = true;
        this.immunityTime = 0f;
    }

    public void GrantImmunity()
    {
        this.isImmuneGranted = true;
        this.immunityTime = 0f;
    }

    public void InstaKill()
    {
        this.lives--;

        if (this.lives == 0)
        {
            Debug.Log("GameOver");
                
            Destroy(this.gameObject);
        }
    }
}
