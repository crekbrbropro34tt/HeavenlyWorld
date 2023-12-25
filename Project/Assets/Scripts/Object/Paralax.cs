using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{

    private float length, startpos, startposY;
    public GameObject cam;
    public float paralaxEffect;
    void Start()
    {
        startpos = transform.position.x;
        startposY = transform.position.y;
        cam = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void Update()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void FixedUpdate()
    {
        float dist = (cam.transform.position.x * paralaxEffect);

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

        float distY = (cam.transform.position.y * paralaxEffect);

        transform.position = new Vector3(transform.position.x, startposY + distY, transform.position.z);
    }
}
