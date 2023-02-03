using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabit : MonoBehaviour
{
    public kind Kind;
    public enum kind
    {
        Cub
    }

    public string TextToKind()
    {
        return "Schau mal sind die Hasen nicht niedlich!";
    }
}
