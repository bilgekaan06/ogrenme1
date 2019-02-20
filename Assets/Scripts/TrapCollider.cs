using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TrapCollider : MonoBehaviour
{
    Animator myAnimator;
    public float currentHealth { get; set; }
    public float maxHealth { get; set; }
    public Slider healthBar;
    public Rigidbody2D myRGB;
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myRGB = GetComponent<Rigidbody2D>();
        maxHealth = 20F;
        currentHealth = maxHealth;
        healthBar.value = calculateHealth();
    }

    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D bilesen)
    {
        if (bilesen.gameObject.tag == "trapcactus")
        {

            if (currentHealth == 5F || currentHealth < 5F)
            {
                myAnimator.SetTrigger("takeDamage");
                damageHealth(5F);
                characterDie();
            }
            else
            {
                myAnimator.SetTrigger("takeDamage");
                damageHealth(5F);

            }
        }

    }
    public float calculateHealth()
    {
        return currentHealth / maxHealth;
    }
    public void damageHealth(float damage)
    {
        currentHealth -= damage;
        healthBar.value = calculateHealth();

    }
    private void characterDie()
    {
        myAnimator.SetTrigger("die");
        myRGB.constraints = RigidbodyConstraints2D.FreezeAll;
        Player.died = true;
    }

}
