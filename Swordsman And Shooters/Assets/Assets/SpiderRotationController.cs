using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderRotationController : MonoBehaviour
{
    GameObject spiderFrontCannonController;

    // Start is called before the first frame update
    void Start()
    {
        spiderFrontCannonController = GameObject.Find("SpiderFrontCannon1");
    }


    // Update is called once per frame
    void Update()
    {
        this.transform.rotation = Quaternion.LookRotation(-spiderFrontCannonController.GetComponent<SpiderFrontCannonController>().dir);
    }
}
