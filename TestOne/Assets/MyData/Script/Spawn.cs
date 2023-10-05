using UnityEngine;
public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject Enemy;
    [SerializeField] private int _caunt;
    private int _counter;
    void Start()
    {
        Vector3 _position = this.transform.position;
        while (_counter != _caunt)
        {
            Instantiate(Enemy, new Vector3(_position.y + (_counter * 2.0f), _position.x, _position.z), Quaternion.identity);
            ++_counter;
        }

    }

}
