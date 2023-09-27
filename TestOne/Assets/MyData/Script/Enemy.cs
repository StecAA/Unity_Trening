using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _speed;
    [SerializeField] private GameObject _weaponPrefab;
    [SerializeField] private GameObject _bulletSpawn;
    
    
    public void Hurt(int damage)
    { 
        _health -= damage;
        if (_health <= 0)
        {
            Die();
            print("«Ямете кудасаи:" + damage);
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }
    private void FixedUpdate()
    {
        //transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _speed * Time.deltaTime );
        //  transform.rotation = 
        //  InvokeRepeating("SpawnBullit", 2, 2);



    }
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.CompareTag("Player")) {
            Debug.Log("Поподание в Тригер" + other);
            StartCoroutine(routine: SpawnBullit());
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // SpawnBullit();
            Run(other.gameObject);
            
        }
    }
    private IEnumerator SpawnBullit()
    { 
          for (int _counter = 0; _counter < 5; ++_counter)
        { 
            yield return new WaitForSeconds(1f);
            Instantiate(_weaponPrefab, new Vector3(_bulletSpawn.transform.position.x + 1, _bulletSpawn.transform.position.y, _bulletSpawn.transform.position.z + 1), Quaternion.identity);
            Debug.Log("Выстрел " + _counter);
        }

    }
    public void Run(GameObject _target)
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _speed * Time.deltaTime);
        transform.Rotate(Vector3.up, _speed * Time.fixedDeltaTime);
    }
}



