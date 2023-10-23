using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    public float minx = 0;
    public float miny = 0;
    public float maxx = 0;
    public float maxy = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (target == null)
        {
            target = GameObject.Find("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Min(Mathf.Max(target.transform.position.x, minx), maxx);
        pos.y = Mathf.Min(Mathf.Max(target.transform.position.y, miny), maxy);
        transform.position = pos;
    }
}
