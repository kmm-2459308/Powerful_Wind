using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cabbageController : MonoBehaviour
{
    Rigidbody2D cabbage;
    public float speed = 0;
    // Start is called before the first frame update
    void Start()
    {
        cabbage = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        cabbage.linearVelocity = new Vector3(speed, cabbage.linearVelocity.y, 0);
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
