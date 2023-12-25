using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialogueIsBool : MonoBehaviour
{
    private bool startDialogBool;

    [SerializeField] private bool nextButton;

    public Dialogue dialogue;

    private bool oneStartDialogue = true;

    private void Update()
    {
        if(startDialogBool && oneStartDialogue)
        {
            oneStartDialogue = false;
            FindObjectOfType<DialogManager>().StartDialogue(dialogue);

            if (nextButton)
            {
                FindObjectOfType<DialogManager>().nextDialogue = true;
            }
        }
    }

    public void StartDialogue(bool dialogueBool)
    {
        startDialogBool = dialogueBool;
    }
}
