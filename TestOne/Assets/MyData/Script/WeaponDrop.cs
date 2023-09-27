using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDrop : MonoBehaviour

{
    private GameObject _target;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
           var _target = collision.gameObject.GetComponent<Player>();
           _target.WeaponEquip();
        };

    }

}
