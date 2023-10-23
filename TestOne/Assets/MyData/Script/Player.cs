
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _weaponPrefab;
    [SerializeField] private GameObject _bulletSpawn;
    [SerializeField] private float _speed;
    [SerializeField] private float _speedRotate = 12f;
    [SerializeField] private int _hitPoint = 100;
    [SerializeField] private float _jumpSize = 1;
    private int _weaponPoint = 0;
    private Vector3 _position = Vector3.zero;
    private bool _isFireLeft;
    private bool _isFireRight;
    private bool _isGrounded;
    Rigidbody _rigidbody;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        _isFireLeft = Input.GetMouseButtonDown(0);
        _isFireRight = Input.GetMouseButtonDown(1);
        _position.x = Input.GetAxis("Horizontal");
        _position.z = Input.GetAxis("Vertical");
        transform.Translate(_position * _speed * Time.fixedDeltaTime);
       transform.Rotate(new Vector3 (0, Input.GetAxis("Mouse X")* _speedRotate, 0), Space.Self);
        transform.Find("Spawn_Fire").transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * _speedRotate * Time.fixedDeltaTime);
        if (_isFireLeft)
        {
            _isFireLeft = false;
            Instantiate(_bulletPrefab, new Vector3(_bulletSpawn.transform.position.x + 1, _bulletSpawn.transform.position.y
                , _bulletSpawn.transform.position.z + 2), Quaternion.identity);
        }
        if (_weaponPoint > 0)
        {
            if (_isFireRight)
            {
                --_weaponPoint;
                _isFireRight = false;
                Instantiate(_weaponPrefab, new Vector3(_bulletSpawn.transform.position.x + 1,
                    _bulletSpawn.transform.position.y, _bulletSpawn.transform.position.z + 1), Quaternion.identity);
                print("Снаярядов:" + _weaponPoint);
            }
        }
        if (_isGrounded)
            if (Input.GetKeyDown(KeyCode.Space))
            {
                RigedbodyJump();
                _isGrounded = false;
            }
    }
    public void WeaponEquip()
    {
        _weaponPoint = _weaponPoint + 100;
        print("Выстрелов:" + _weaponPoint);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.TryGetComponent(out Mine mine))
        { 
        _isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        _isGrounded = false;
    }
    private void RigedbodyJump()
    {
        _rigidbody.AddForce(new Vector3(0, _jumpSize, 0) * _speed, ForceMode.VelocityChange);
    }


}
