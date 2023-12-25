using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrueTriggerObject : MonoBehaviour
{

    [SerializeField] private GameObject trueTriggerObject;
    [SerializeField] private string tagObject;
    [SerializeField] private bool exitTrigger;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag(tagObject))
        {
            trueTriggerObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if(exitTrigger)
        {
            if (col.CompareTag(tagObject))
            {
                trueTriggerObject.SetActive(false);
            }
        }
    }
}
