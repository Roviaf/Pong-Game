using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableBall : MonoBehaviour
{
    [SerializeField]GameObject ball;
    [SerializeField] float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        var ballInstantiate = Instantiate(ball);
        ballInstantiate.transform.parent = gameObject.transform;
        gameObject.transform.position = transform.position + new Vector3(-2, 0, 0) * Time.deltaTime * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
