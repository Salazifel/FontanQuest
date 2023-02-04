using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deer : MonoBehaviour
{
    public kind Kind;
    public enum kind
    {
        Doe,
        Calf
    }
    public string TextToKind()
    {
        switch (Kind)
        {
            case kind.Doe:
                return "Die Rehe sehen sehr entspannt aus sie scheinen an Menschen gewoehnt zu sein";
            case kind.Calf:
                return "Das Rehkitz ist ja zum anbeißen";
                default:
                return "Rehe!";
        }
    }
}
