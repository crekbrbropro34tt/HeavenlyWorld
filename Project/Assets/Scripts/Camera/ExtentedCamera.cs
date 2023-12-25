using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ExtentedCamera : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    private bool extented;

    [SerializeField]  private float maxExtented;
    [SerializeField]  private float normalCamera = 10f;
    [SerializeField]  private float timeExtented;

    [SerializeField] private bool deleteTrigger;

    [SerializeField] private float speedExtented;

    private void Awake()
    {
        virtualCamera = GameObject.FindGameObjectWithTag("VirtualCamera").GetComponent<CinemachineVirtualCamera>();
    }

    private void Update()
    {
        if(extented)
        {
            if(virtualCamera.m_Lens.OrthographicSize < maxExtented)
            {
                virtualCamera.m_Lens.OrthographicSize += speedExtented * Time.deltaTime;
            }
        } else
        {
            if (virtualCamera.m_Lens.OrthographicSize > normalCamera)
            {
                virtualCamera.m_Lens.OrthographicSize -= speedExtented * Time.deltaTime;
            } else
            {
   
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Collider2D collider = GetComponent<Collider2D>();
        if(col.CompareTag("Player"))
        {
            StartCoroutine(ExtentedIE());

            if (deleteTrigger)
            {
                Destroy(collider);
            }
        }
    }


    IEnumerator ExtentedIE()
    {
        extented = true;
        yield return new WaitForSeconds(timeExtented);
        extented = false;
    }
}
