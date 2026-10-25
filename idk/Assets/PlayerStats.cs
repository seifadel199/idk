using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int health = 100;
    public int life = 3;

    private float flickerTime = 0f;
    public float flickerDuration = 0.1f;

    private SpriteRenderer sr;

    public bool isImmune = false;
      private float ImmunityTime = 0f;
    public float ImmunityDuration = 1.5f;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isImmune == true)
        {
            SpriteFlicker();
            ImmunityTime = ImmunityTime + Time.deltaTime;
            if(ImmunityTime > ImmunityDuration)
            {
                isImmune = false;
                sr.enabled = true;
            }
        }
    }

    void SpriteFlicker()
    {
        if (flickerTime < flickerDuration)
        {
            flickerTime = flickerTime + Time.deltaTime;
           
        }
        else if (ImmunityTime < ImmunityDuration)
        {
          sr.enabled = !(sr.enabled);  
          
         flickerTime = 0;
        }
    }
    public void TakeDamage(int damage)
        {
            if(isImmune == false)
            {
                health = health - damage;
                if(health < 0)
                { 
                    health = 0;
                }
                if(health == 0 && life > 0) 
                {
                    FindObjectOfType<LevelManager>().RespawnPlayer();
                    health = 100;
                    life--;
                }
                else if(health == 0 && life == 0)
                {
                   Debug.Log("Game Over");
                   Destroy(this.gameObject);
                }
                Debug.Log("Player Health: " + health.ToString());
                Debug.Log("Player Life: " + life.ToString());
            }
            isImmune = true;
            ImmunityTime = 0;
        }
    }

