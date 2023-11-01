using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _speed;
    [SerializeField] private GameObject _weaponPrefab;
    [SerializeField] private GameObject _bulletSpawn;
    [SerializeField] private float _fireTime = 1f;
    [SerializeField] private GameObject _target;
    [SerializeField] private Transform[] _wayPoints;
    private float _timeCounter;
    private int _currentWayPointIndex;
    private NavMeshAgent _agent;
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        if (_wayPoints.Length == 0) return;
        if (!_agent.pathPending && _agent.remainingDistance < 0.5f) GotoNextPoint();
    }
    private void GotoNextPoint()
    {

        _agent.destination = _wayPoints[_currentWayPointIndex].position;
        _currentWayPointIndex = (_currentWayPointIndex + 1) % _wayPoints.Length;

    }
    public void Hurt(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            Run(other.gameObject);
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
    }
    private IEnumerator SpawnBullet()
    {
        yield return new WaitForSeconds(1f);
        Vector3 _position = new Vector3(_bulletSpawn.transform.position.x,
        _bulletSpawn.transform.position.y, _bulletSpawn.transform.position.z);
        Instantiate(_weaponPrefab, _position, Quaternion.identity);
    }
    public void Run(GameObject _target)
    {
        Debug.Log("Бег" + _target.transform.position);
        _agent.destination = _target.transform.position;
        Debug.Log("1" + _agent.destination);
        transform.Rotate(Vector3.up, _speed * Time.fixedDeltaTime);
    }
}



