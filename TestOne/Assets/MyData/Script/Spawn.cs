using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject Enemy;
    [SerializeField] private int _caunt;
    private int _caunter = 0;
    
    // Start is called before the first frame update
    void Start()
    { 
        Vector3 _position = this.transform.position;
        while ( _caunter != _caunt)
        {
            Instantiate(Enemy, new Vector3(_position.y+(_caunter*2.0f), _position.x, _position.z),Quaternion.identity );
            ++_caunter;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
