using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public GameObject playerBody;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        playerBody = GameObject.Find("PlayerBody");
        offset = transform.position - playerBody.transform.position;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = playerBody.transform.position + offset;
    }
}
