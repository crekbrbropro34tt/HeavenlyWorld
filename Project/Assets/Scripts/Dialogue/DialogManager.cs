using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text DialogueText;
    public Image SpriteHead;
    public SpriteRenderer NPC;


    public Queue<string> Setences;
    public Queue<string> Name;

    public Queue<Sprite> Head;

    public Queue<float> timeDialog;

    public Animator anim;

    public float timeDialogue;


    public bool nextDialogue;

    [SerializeField] private GameObject nextButton;

    private bool trueTimeScale;

    public static bool endDialogue;

    private void Start()
    {
        Setences = new Queue<string>();
        Name = new Queue<string>();
        Head = new Queue<Sprite>();
        timeDialog = new Queue<float>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        anim.SetBool("isOpen", true);

        endDialogue = false;

        //nameText.text = dialogue.name;

        Setences.Clear();

        foreach (Sprite head in dialogue.head)
        {
            Head.Enqueue(head);
        }

        foreach (float times in dialogue.timeDialogue)
        {
            timeDialog.Enqueue(times);
        }


        foreach (string name in dialogue.name)
        {
            Name.Enqueue(name);
        }

        foreach (string setences in dialogue.setences)
        {
            Setences.Enqueue(setences);
        }

        DisplayNextSetence();
    }

    public void DisplayNextSetence()
    {
        if (Setences.Count == 0)
        {
            Time.timeScale = 1;
            EndDialogue();
            return;
        }

        float timeDialogs = timeDialog.Dequeue();
        string setence = Setences.Dequeue();
        string name = Name.Dequeue();
        Sprite head = Head.Dequeue();

        StopCoroutine(TypeSetence(setence, name, head, timeDialogs));
        StartCoroutine(TypeSetence(setence, name, head, timeDialogs));
    }

    IEnumerator TimeScaleDialogue()
    {
        yield return new WaitForSeconds(.30f);
        trueTimeScale = true;
    }


    IEnumerator TypeSetence(string sentence, string name, Sprite head, float time)
    {
        timeDialogue = time;
        DialogueText.text = "";
        nameText.text = name;
        SpriteHead.sprite = head;
        foreach (char letter in sentence.ToCharArray())
        {
            DialogueText.text += letter;
            yield return null;
        }
        if (!nextDialogue)
        {
            StartCoroutine(NextText());
            nextButton.SetActive(false);
        }
        else if (nextDialogue)
        {
            //Time.timeScale = 0;
            nextButton.SetActive(true);
        }


    }

    public void Next()
    {
        DisplayNextSetence();
    }



    IEnumerator NextText()
    {
        yield return new WaitForSeconds(timeDialogue);
        DisplayNextSetence();
    }

    void EndDialogue()
    {
        anim.SetBool("isOpen", false);
        //Time.timeScale = 1;
        endDialogue = true;
        nextDialogue = false;
    }

}
