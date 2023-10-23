using UnityEngine;

public class Door : MonoBehaviour
{
    private bool _counter = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (_counter)
            {
                Debug.Log("Открытие двери");
                transform.Rotate(new Vector3(0, 120, 0));
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
                _counter = false;
            }
            else
            {
                Debug.Log("Закрытие двери");
                transform.Rotate(new Vector3(0, -120, 0));
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
                _counter = true;
            }
        }
    }
}
