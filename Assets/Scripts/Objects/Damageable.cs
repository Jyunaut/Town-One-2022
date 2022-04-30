using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Damageable
{
   int HP
    {
        get;
        set;
    }

    int MaxHP
    {
        get;
    }

    public int receiveDamage(int dmg);

    public void onDeath();

}
