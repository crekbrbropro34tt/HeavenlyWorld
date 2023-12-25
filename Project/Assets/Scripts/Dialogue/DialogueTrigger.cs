using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public bool catscene;
    public bool trueDialog;

    public bool nextButton;

    public bool nonDes;

    private BoxCollider2D desCollider;


    private void Start()
    {
        desCollider = GetComponent<BoxCollider2D>();
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogManager>().StartDialogue(dialogue);

  

        if (nextButton)
        {
            FindObjectOfType<DialogManager>().nextDialogue = true;
        }

    }

    private void Update()
    {
        if (catscene)
        {
            if (trueDialog)
            {
                catscene = false;
                TriggerDialogue();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            TriggerDialogue();
            desCollider.enabled = false;
            if (!nonDes)
            {
                Destroy(gameObject);
            }
        }
    }
}
