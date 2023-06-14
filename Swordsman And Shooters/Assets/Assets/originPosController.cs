using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class originPosController : MonoBehaviour
{
    GameObject spider = GameObject.Find("SpiderPrefab");
    Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector3(0f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        direction  = spider.GetComponent<SpiderMoveController>().originPos - this.transform.position;
        this.transform.Translate(direction);
    }
}
