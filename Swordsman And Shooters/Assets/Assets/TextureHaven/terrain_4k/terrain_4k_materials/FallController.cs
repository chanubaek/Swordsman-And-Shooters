using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallController : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "PLAYER")
        {
            Debug.Log("fall");
        }
    }
}
