using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paperController : MonoBehaviour
{
    Rigidbody2D paper;
    public float speed = 0;
    // Start is called before the first frame update
    void Start()
    {
        paper = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        paper.linearVelocity = new Vector3(speed, paper.linearVelocity.y, 0);
        if (transform.position.x > 15.0f)
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
