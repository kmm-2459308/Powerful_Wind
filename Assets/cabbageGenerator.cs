using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cabbageGenerator : MonoBehaviour
{
    public GameObject cabbagePrefab;
    float span = 5.0f;
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
            GameObject go = Instantiate(cabbagePrefab);
            int px = Random.Range(-3, 4);
            go.transform.position = new Vector3(-11, px, 0);
        }
    }
}
