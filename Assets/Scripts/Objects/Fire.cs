using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : PlaceableObj, Damageable
{
    public int hp;
    public FireData data;
    HealthBar healthBar;

    delegate void damageHandler(int cur, int max);
    event damageHandler onDamaged;

    private void Awake()
    {
        hp = MaxHP;
        healthBar = GetComponent<HealthBar>();
        onDamaged += healthBar.changeHealthBar;
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
        Destroy(this.gameObject);
        return;
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
}
