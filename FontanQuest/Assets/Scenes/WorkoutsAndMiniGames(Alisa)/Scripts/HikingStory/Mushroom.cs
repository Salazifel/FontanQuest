using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{

    public MushroomKind Kind;

    public enum MushroomKind
    {
        Violaceus,
        Boletus, //german: Steinpilz
        GreenToadStool, // german: grüner Giftpilz
        ToadStool, // german: Fliegenpilz
    }

    public string TextToMushroomKind()
    {
        switch (Kind)
        {
            case MushroomKind.Violaceus:
                return "Gut gemacht, das ist genau wonach wir gesucht haben.";
            case MushroomKind.Boletus:
                return "Nein von dieser Sorte gibt es viel zu viele wir suchen einen sehr seltenen Pilz";
            case MushroomKind.GreenToadStool:
                return "Ich glaube nicht das diese Pilze zur Art der Violaceus Pilze gehören";
            case MushroomKind.ToadStool:
                return "Das ist ein stink normaler Fliegenpilz, such weiter";
            default:
                return "Das ist nicht das wonach wir suchen";
        }
    }

}
