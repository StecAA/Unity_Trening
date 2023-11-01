using System;
using UnityEngine;
public class Camera : MonoBehaviour
{
    public Transform _target;
    public Vector3 _offset;
    public float _sensitivity = 3; // ���������������� �����
    public float _limit = 80; // ����������� �������� �� Y
    public float _zoom = 0.25f; // ���������������� ��� ����������, ��������� �����
    public float _zoomMax = 10; // ����. ����������
    public float _zoomMin = 3; // ���. ����������
    private float X, Y;
    void Start()
    {
        _limit = Mathf.Abs(_limit);
        if (_limit > 90) _limit = 90;
        _offset = new Vector3(_offset.x, _offset.y, -Mathf.Abs(_zoomMax) / 2);
        transform.position = _target.position + _offset;
    }
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0) _offset.z += _zoom;
        else if (Input.GetAxis("Mouse ScrollWheel") < 0) _offset.z -= _zoom;
        _offset.z = Mathf.Clamp(_offset.z, -Mathf.Abs(_zoomMax), -Mathf.Abs(_zoomMin));

        X = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * _sensitivity;
        Y += Input.GetAxis("Mouse Y") * _sensitivity;
        Y = Mathf.Clamp(Y, -_limit, _limit);
        transform.localEulerAngles = new Vector3(-Y, X, 0);
        transform.position = transform.localRotation * _offset + _target.position;
    }
}
