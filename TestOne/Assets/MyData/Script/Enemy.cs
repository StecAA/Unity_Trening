using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _speed;
    [SerializeField] private GameObject _weaponPrefab;
    [SerializeField] private GameObject _bulletSpawn;
    [SerializeField] private float _fireTime = 1f;
    [SerializeField] private GameObject _target;
    public Transform[] _wayPoints;
    private float _timeCounter;
    private int _currentWayPointIndex;
    private NavMeshAgent _agent;
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }
    private void FixedUpdate()
    {
        if (!_agent.pathPending && _agent.remainingDistance < 0.5f) GotoNextPoint();

        //if (_agent.remainingDistance < _agent.stoppingDistance)
        //{
        //    _currentWayPointIndex = (_currentWayPointIndex+1) % _wayPoint.Length;
        //    _agent.SetDestination(_wayPoint[_currentWayPointIndex].position);
        //}
    }
    private void GotoNextPoint()
    {
        if (_wayPoints.Length == 0) return;
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
        Debug.Log("Выстрел ");
    }
    public void Run(GameObject _target)
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _speed * Time.deltaTime);
        transform.Rotate(Vector3.up, _speed * Time.fixedDeltaTime);
    }
}



