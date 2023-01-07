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
                return "Yes, that must be the right one. Good Job.";
            case MushroomKind.Boletus:
                return "No there are way to many of this kind in this meadow";
            case MushroomKind.GreenToadStool:
                return "Mhm they grow in groups, the healer said that they are very rare";
            case MushroomKind.ToadStool:
                return "I am pretty sure that that is an Toadstool";
            default:
                return "No thats not what we are looking for";
        }
    }

}
