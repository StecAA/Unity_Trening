using UnityEngine;
public class Spear : MonoBehaviour
{
    private Vector3 _target;

    [SerializeField] int _deamge = 10;

    private void Start()
    {
        if (GameObject.FindGameObjectWithTag("EnemyTag") == null) return;
        _target = GameObject.FindGameObjectWithTag("EnemyTag").transform.position;
    }
    private void Update()
    {
      
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, _target, 1f);

    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enamy))
        {
            var enemy = other.gameObject.GetComponent<Enemy>();
            enemy.Hurt(_deamge);
            Destroy(gameObject);
        }

    }
}
