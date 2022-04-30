using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHealthBar : MonoBehaviour
{
    public int currentHP;
    public int fullHP;

    HealthBar healthBar;
    void Awake()
    {
        healthBar = GetComponent<HealthBar>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.changeHealthBar(currentHP, fullHP);
    }
}
