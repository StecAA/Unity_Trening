using System.Collections;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private Transform _target;
    [SerializeField] private Transform _head;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private GameObject _weaponPrefab;
    [SerializeField] private GameObject _bulletSpawn;
    [SerializeField] private float _fireTime = 1f;
    private float _timeCounter;
    private Vector3 _direction;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            _target = other.transform;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            _target = null;
        }

    }
    private void FixedUpdate()
    {
        if (_target == null) return;
        _direction = _target.position - _head.position;
        _direction.Set(_direction.x, 0, _direction.z);
        Vector3 _stepDirection = Vector3.RotateTowards(_head.forward, _direction, _speed * Time.fixedDeltaTime, 0.0f);
        _head.rotation = Quaternion.LookRotation(_stepDirection);
        if (_timeCounter < _fireTime)
        {
            _timeCounter += Time.fixedDeltaTime;
            return;
        }
        else
        {
            _timeCounter = 0;
            StartCoroutine(routine: SpawnBullet());
        }



    }
    private IEnumerator SpawnBullet()
    {
        yield return new WaitForSeconds(1f);

        Instantiate(_weaponPrefab, new Vector3(_bulletSpawn.transform.position.x, 
            _bulletSpawn.transform.position.y, _bulletSpawn.transform.position.z), Quaternion.identity);
        Debug.Log("Выстрел");


    }
}
