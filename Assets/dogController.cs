using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dogController : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D dog;
    public float speed = 0;
    // Start is called before the first frame update
    void Start()
    {
        dog = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dog.linearVelocity = new Vector3(speed, dog.linearVelocity.y, 0);
        if (transform.position.x > 12.0f)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("wall"))
        {
            Destroy(gameObject);
        }
    }
}
