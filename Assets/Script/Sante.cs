using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sante : MonoBehaviour
{

    [SerializeField]
    Slider sliderVie;

    [SerializeField]
    Text textVie;

    [SerializeField]
    float startHealth;

    [SerializeField]
    ParticleSystem deathParticle;



    float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startHealth;
        sliderVie.maxValue = startHealth;
        sliderVie.value = startHealth;
        textVie.text = startHealth + "%";
    }
    
    public void DoDamage(float damage)
    {
        currentHealth -= damage;
        sliderVie.value = currentHealth;
        if(gameObject.tag == "Player")
        {
            textVie.text = currentHealth + "%";
        }

        if (currentHealth <= 0)
        {
            if(gameObject.tag == "Player")
            {
                GameManager.gameOver = true;
            }

            if(gameObject.tag == "Enemy")
            {
                GameManager.instance.addScore(10f);
            }

            Instantiate(deathParticle, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
    }

    public void heal(float healAmount)
    {
        currentHealth += healAmount;

        if(currentHealth > startHealth)
        {
            currentHealth = startHealth;
        }

        sliderVie.value = currentHealth;
        textVie.text = currentHealth + "%";
    }
}
