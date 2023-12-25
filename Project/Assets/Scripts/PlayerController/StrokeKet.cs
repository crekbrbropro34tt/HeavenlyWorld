using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class StrokeKet : MonoBehaviour
{
    [Header("Components")]
    private PlayerController player;
    [SerializeField] private GameObject spritePlayer;
    [SerializeField] private GameObject hand;
    [SerializeField] private GameObject animeStrokePlayer;
    public static Transform PointPosition;

    [Header("Settings")]
    [SerializeField] private float timeStroke;

    [Header("Camera")]
    private CinemachineVirtualCamera virtualCamera;
    private bool extentedCamera;
    [SerializeField] private float extentedMin, extentedNormal, speedExtented;
    private float extented;
    private bool nonExtented;

    private void Awake()
    {
        extented = 3;
        player = GetComponent<PlayerController>();
        virtualCamera = GameObject.FindGameObjectWithTag("VirtualCamera").GetComponent<CinemachineVirtualCamera>();
    }

    private void Update()
    {
        if(extentedCamera)
        {
            virtualCamera.m_Lens.OrthographicSize = extented;
            transform.position = PointPosition.position;
            transform.localRotation = PointPosition.localRotation;

            CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannel = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

            cinemachineBasicMultiChannel.m_AmplitudeGain = 0;

            if (extented > extentedMin)
            {
                extented -= Time.deltaTime * speedExtented;
            } else
            {
                extented = extentedMin;
            }
        } else 
        {
            if (!nonExtented)
            {
                virtualCamera.m_Lens.OrthographicSize = extented;
                if (extented < extentedNormal)
                {
                    extented += Time.deltaTime * speedExtented;
                }
                else
                {
                    nonExtented = true;
                    extented = extentedNormal;
                }
            }
        }
    }

    public void Stroke()
    {
        StartCoroutine(StrokeIE());
    }

    IEnumerator StrokeIE()
    {
        nonExtented = false;
        player.enabled = false;

        spritePlayer.SetActive(false);
        hand.SetActive(false);
        animeStrokePlayer.SetActive(true);

        extentedCamera = true;

        yield return new WaitForSeconds(timeStroke);
        extentedCamera = false;

        spritePlayer.SetActive(true);
        hand.SetActive(true);
        animeStrokePlayer.SetActive(false);

        player.enabled = true;
    }

}
