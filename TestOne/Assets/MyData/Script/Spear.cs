using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Spear : MonoBehaviour
{
    private  Vector3 _target;

    [SerializeField] int _deamge=10;

   
    void FixedUpdate()
    {

        _target = GameObject.FindGameObjectWithTag("EnemyTag").transform.position;
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, _target,1f);
   

    }
    private void OnCollisionEnter(Collision other)
    {
        print("fier:");
        if (other.gameObject.CompareTag("EnemyTag"))
        {
            print("fier:");
            var enemy = other.gameObject.GetComponent<Enemy>();
            enemy.Hurt(_deamge);
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Player"))
        {
            print("fier Die:");
            Destroy(gameObject);
        }

    }
}
