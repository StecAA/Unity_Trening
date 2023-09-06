using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _bulletSpawn;
    [SerializeField] private float _speed;
    private Vector3 _position = Vector3.zero;
    private bool _isFier;
    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        _isFier = Input.GetMouseButtonDown(0);
     
    }

    void FixedUpdate()
    {
        _position.x = Input.GetAxis("Horizontal");
        _position.z = Input.GetAxis("Vertical");
        transform.Translate(_position*_speed*Time.fixedDeltaTime);
        if (_isFier)
        {
            _isFier = false;
            Instantiate(_bulletPrefab, new Vector3 (_bulletSpawn.transform.position.x+1, _bulletSpawn.transform.position.y, _bulletSpawn.transform.position.z+2), Quaternion.identity);
        }
    }
    void LateUpdate()
    {

    }
}
