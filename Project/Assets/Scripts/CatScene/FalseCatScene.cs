using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalseCatScene : MonoBehaviour
{
    [SerializeField] private bool falseCatscene;

    [SerializeField] private GameObject Catsscene;
    [SerializeField] private GameObject[] TrueObjects;

    private Animator blackScreenAnim;

    private void Start()
    {
        blackScreenAnim = GameObject.FindGameObjectWithTag("BlackScreen").GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Tab))
        {
            StartCoroutine(blackScreen());
        }

        if(falseCatscene)
        {
            StartCoroutine(blackScreen());

        }
    }

    IEnumerator blackScreen()
    {
        blackScreenAnim.SetBool("true", true);
        yield return new WaitForSeconds(0.5f);
        Catsscene.SetActive(false);

        for (int i = 0; i < TrueObjects.Length; i++)
        {
            TrueObjects[i].SetActive(true);
        }
        blackScreenAnim.SetBool("true", false);

    }
}
