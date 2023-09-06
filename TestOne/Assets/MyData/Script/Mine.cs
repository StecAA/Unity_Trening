using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private int _damage;
    // Start is called before the first frame update]

    private void OnTriggerEnter(Collider other)
    {
    
        if (other.gameObject.CompareTag("EnemyTag"))
        {
            var enemy = other.gameObject.GetComponent<Enemy>();
            enemy.Hurt(_damage);
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
