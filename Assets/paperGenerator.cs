using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paperGenerator : MonoBehaviour
{
    public GameObject paperPrefab;
    float span = 2.0f;
    float delta = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject go = Instantiate(paperPrefab);
            int px = Random.Range(-4, 4);
            go.transform.position = new Vector3(-10, px, 0);
        }
    }
}
