using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Fire : PlaceableObj, Damageable
{
    public int hp;
    public FireData data;
    HealthBar healthBar;
    public AudioClip deathSFX;

    private Animator animator;
    private Transform ObjectTransform;

    delegate void damageHandler(int cur, int max);
    event damageHandler onDamaged;

    private void Awake()
    {
        hp = MaxHP;
        healthBar = GetComponent<HealthBar>();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        onDamaged += healthBar.changeHealthBar;
    }

    private void OnDisable()
    {
        onDamaged -= healthBar.changeHealthBar;
    }

    public int HP {
        get
        {
            return hp;
        }
        set
        {
            hp = value;
        }
    }


    public int MaxHP
    {
        get
        {
            return data.maxHP;
        }
    }

    public void onDeath()
    {
        Debug.Log("you died");
        StartCoroutine(playDeathAnimation());
        return;
    }

    private IEnumerator playDeathAnimation()
    {
        animator.Play("Death");
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }

    public int receiveDamage(int dmg)
    {
        var currHp = Mathf.Clamp(hp - dmg, 0, data.maxHP);
        onDamaged?.Invoke(currHp, data.maxHP);
        if (currHp==0)
        {
            onDeath();
        }
        Debug.Log("HP: " + hp);
        hp = currHp;
        return currHp;
    }

    private void Update()
    {

        // Animate the fire
        // - angle it
        // - make it jiggle, 
        // - spawn particle effects over time
        /*
        float fire_scale_jiggle_max     = 0.25f;
        float fire_scale_jiggle_speed   = 0.1f;
        float fire_scale_jiggle_time    = Time.deltaTime * 100000;
        float fire_scale                = (float) (1 + fire_scale_jiggle_max * (Math.Cos(Mathf.Deg2Rad * fire_scale_jiggle_time * fire_scale_jiggle_speed)));

        gameObject.transform.localScale = new Vector3(fire_scale, fire_scale, 1);
        */
    }
}
