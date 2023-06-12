using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderTailGunController : MonoBehaviour
{
    GameObject playerBody;
    public Vector3 dir = new Vector3(0f, 0f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GameObject.Find("PlayerBody");
    }
    public Vector3 GetDir()
    {
        return this.dir;
    }

    // Update is called once per frame
    void Update()
    {
        dir.x = playerBody.transform.position.x - this.transform.position.x;
        dir.z = playerBody.transform.position.z - this.transform.position.z;

    }
}
