using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderTailController : MonoBehaviour
{

    public float degreePerSecond;
    public Quaternion direction;
    public Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        //direction = new Vector3()
        direction = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        position = this.transform.position;
        transform.Rotate(Vector3.up * Time.deltaTime * degreePerSecond);
        direction = transform.rotation;
        //direction = k
        //direction = new Vector3(-Mathf.Sin(Time.deltaTime * degreePerSecond), 0f, Mathf.Cos(Time.deltaTime * degreePerSecond));
    }
}
