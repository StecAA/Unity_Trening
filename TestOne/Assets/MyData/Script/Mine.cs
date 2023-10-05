
using UnityEngine;
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
        if (other.gameObject.TryGetComponent(out Player player)) { 
        print("Fire Die:");
        Destroy(gameObject);
        }
    }
}