using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class HealthSystem : MonoBehaviour
{
    public int health;
    public int numberOfLives;

    public Image[] lives;

    public Sprite fullLive;
    public Sprite emptyLive;
    
    public UnityEvent onDied;

    void Start()
    {

    }

    void Update()
    {
        if (health == 0) {
            onDied?.Invoke();
        }

        if(health > numberOfLives)
        {
            health = numberOfLives;
        }

        for(int i = 0; i < lives.Length; i++)
        {
            if(i < health)
            {
                lives[i].sprite = fullLive;
            }
            else
            {
                lives[i].sprite = emptyLive;
            }

            if(i < numberOfLives)
            {
                lives[i].enabled = true;
            }
            else
            {
               lives[i].enabled = false;
            }
        }
    }
}