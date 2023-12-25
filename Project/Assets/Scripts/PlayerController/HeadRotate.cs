using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadRotate : MonoBehaviour
{
    private float rotateZ;

    [SerializeField] private Transform HeadPosition;


    private bool Angle, Angle2;


    private Vector3 pos;

    private Camera cam;

    private Vector3 LocalScale = Vector3.one;



    private void Update()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        HeadRotation();

        RotateZExamination();

        pos = cam.WorldToScreenPoint(transform.position);
    }

    private void RotateZExamination()
    {

            if (Input.mousePosition.x > pos.x)
            {
                if (rotateZ <= 30)
                {
                    Angle = true;
                }
                else if (rotateZ > 30)
                {
                    Angle = false;
                    rotateZ = 28;
                    HeadPosition.rotation = Quaternion.Euler(0, 0, rotateZ);
                }

                if (rotateZ >= -30)
                {
                    Angle = true;
                }
                else if (rotateZ < -30)
                {
                    Angle = false;
                    rotateZ = -28;
                    HeadPosition.rotation = Quaternion.Euler(0, 0, rotateZ);
                }

            }

            if (Input.mousePosition.x < pos.x)
            {
                if (rotateZ <= 30)
                {
                    Angle2 = true;
                }
                else if (rotateZ > 30)
                {
                    Angle2 = false;
                    rotateZ = 28;
                    HeadPosition.rotation = Quaternion.Euler(0, 180, rotateZ);
                }

                if (rotateZ >= -30)
                {
                    Angle2 = true;
                }
                else if (rotateZ < -30)
                {
                    Angle2 = false;
                    rotateZ = -28;
                    HeadPosition.rotation = Quaternion.Euler(0, 180, rotateZ);
                }

            
        }
    }

    private void HeadRotation()
    {

            if (Input.mousePosition.x > pos.x)
            {
                if (Angle)
                {
                    Vector3 diference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                    rotateZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);
                }
            }
            else if (Input.mousePosition.x < pos.x)
            {
                if (Angle2)
                {
                    Vector3 diference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                    rotateZ = Mathf.Atan2(diference.y, -diference.x) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.Euler(0f, 180f, rotateZ);
                }
            }
        
    }
}
