using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Mine : MonoBehaviour
{
    [SerializeField] private int _damage;
    Vector3 _target;
    private void FixedUpdate()
    {
        _target = GameObject.FindGameObjectWithTag("Player").transform.position;
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, _target, 1f);

    }
    private void OnCollisionEnter(Collision other)
    {

    
      //  if (other.gameObject.CompareTag("EnemyTag"))
      //  {
          //  var enemy = other.gameObject.GetComponent<Enemy>();
        //    enemy.Hurt(_damage);
       //     Destroy(gameObject);
       // }
        if (other.gameObject.CompareTag("Player"))
        {
            print("fier Die:");
            Destroy(gameObject);
        }
    }

}
