using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrueCatScene : MonoBehaviour
{
    [SerializeField] private GameObject PressF;
    private bool enterLocation;

    [SerializeField] private GameObject catScene;
    [SerializeField] private GameObject[] falseObject;


    private void Update()
    {
        if (enterLocation)
        {
            if (Input.GetKey(KeyCode.F))
            {
                for (int i = 0; i < falseObject.Length; i++)
                {
                    falseObject[i].SetActive(false);
                }

                catScene.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            enterLocation = true;
            PressF.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            enterLocation = false;
            PressF.SetActive(false);
        }
    }
}
