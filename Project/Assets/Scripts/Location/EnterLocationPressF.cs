using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterLocationPressF : MonoBehaviour
{
    [SerializeField] private GameObject PressF;
    private bool enterLocation;

    [SerializeField] private GameObject LocationOne, LocationTo;
    [SerializeField] private Transform  Point;

    private void Update()
    {
        if(enterLocation)
        {
            if(Input.GetKey(KeyCode.F))
            {
                LocationOne.SetActive(false);
                LocationTo.SetActive(true);
                Transform player = GameObject.FindGameObjectWithTag("Player").transform;
                player.position = Point.position;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            enterLocation = true;
            PressF.SetActive(enterLocation);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            enterLocation = false;
            PressF.SetActive(enterLocation);
        }
    }
}
