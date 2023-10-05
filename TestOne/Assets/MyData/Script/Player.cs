
using UnityEngine;
public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _weaponPrefab;
    [SerializeField] private GameObject _bulletSpawn;
    [SerializeField] private float _speed;
    [SerializeField] private float _speedRotate = 150;
    [SerializeField] private int _hitPoint = 100;
    private int _weaponPoint = 0;
    private Vector3 _position = Vector3.zero;
    private bool _isFireLeft;
    private bool _isFireRight;
    void Update()
    {
        _isFireLeft = Input.GetMouseButtonDown(0);
        _isFireRight = Input.GetMouseButtonDown(1);

    }

    void FixedUpdate()
    {
        _position.x = Input.GetAxis("Horizontal");
        _position.z = Input.GetAxis("Vertical");
        _position.y = Input.GetAxis("Jump");
        transform.Translate(_position * _speed * Time.fixedDeltaTime);
        transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * _speedRotate * Time.fixedDeltaTime);
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
    }
    public void WeaponEquip()
    {
        _weaponPoint = _weaponPoint + 100;
        print("Выстрелов:" + _weaponPoint);

    }

}
