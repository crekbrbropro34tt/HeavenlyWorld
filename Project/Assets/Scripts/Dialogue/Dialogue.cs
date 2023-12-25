using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialogue
{

    public string[] name;

    public Sprite[] head;

    public float[] timeDialogue;

    [TextArea(3, 10)]
    public string[] setences;
}
