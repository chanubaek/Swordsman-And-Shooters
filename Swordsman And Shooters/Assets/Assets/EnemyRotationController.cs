using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotationController : MonoBehaviour
{
    GameObject gunController;

    // Start is called before the first frame update
    void Start()
    {
        gunController = GameObject.Find("EnemyGun");
    }


    // Update is called once per frame
    void Update()
    {
        this.transform.rotation = Quaternion.LookRotation(-gunController.GetComponent<GunController>().dir);
    }
}
