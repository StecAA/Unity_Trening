using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    public void Hurt(int damage)
    {
        print("Ђямете кудасаи:" + damage);
        _health-=damage;
        if (_health<=0)
        {

            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
