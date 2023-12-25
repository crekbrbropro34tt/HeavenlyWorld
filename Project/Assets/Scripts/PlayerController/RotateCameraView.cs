using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCameraView : MonoBehaviour
{
    private float rotateZ;

    [SerializeField] private float offset;

    private Vector3 LocalScale;


    void Update()
    {
        Vector3 diference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);

        LocalScale = Vector3.one;

        if (rotateZ > 90 || rotateZ < -90)
        {
            LocalScale.y = -1f;
        }
        else
        {
            LocalScale.y = +1f;
        }

        transform.localScale = LocalScale;
    }
}
