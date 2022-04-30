using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : PlaceableObj, Damageable
{
    int hp;
    int maxHP;
    FireData data;

    delegate void damageHandler(int cur, int max);
    event damageHandler onDamaged;
    
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
        return currHp;
    }
}
