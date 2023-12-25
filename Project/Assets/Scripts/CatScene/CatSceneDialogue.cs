using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSceneDialogue : MonoBehaviour
{
    [SerializeField] private bool startDialogue;

    [SerializeField] private StartDialogueIsBool[] dialogue;

    [SerializeField] private int nummerDialogue;

    [SerializeField] private Animator anim;

    private void Update()
    {
        if(startDialogue)
        {
            dialogue[nummerDialogue].StartDialogue(true);
            anim.SetBool("idle", true);
        } 

        if(DialogManager.endDialogue)
        {
            startDialogue = false;
            anim.SetBool("idle", false);
        }
    }
}
