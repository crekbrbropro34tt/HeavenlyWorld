using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StokeKetTriggerActive : MonoBehaviour
{
    [SerializeField] private Transform Point;
    private bool EnterTrigger;

    private StrokeKet stroke;

    [SerializeField] private GameObject pressF;

    private void Start()
    {

        pressF.SetActive(false);
        if (transform.rotation.y == 180)
        {
            Point.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (transform.rotation.y == 0)
        {
            Point.localRotation = Quaternion.Euler(0, 180, 0);
        }

    }

    private void Update()
    {
        if(EnterTrigger)
        {
            if (Input.GetKey(KeyCode.F))
            {
                StrokeKet.PointPosition = Point;
                stroke.Stroke();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        stroke = col.GetComponent<StrokeKet>();

        if(stroke != null)
        {
            pressF.SetActive(true);
            EnterTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        StrokeKet stroke = col.GetComponent<StrokeKet>();

        pressF.SetActive(false);

        if (stroke != null)
        {
            EnterTrigger = false;
        }
    }
}
