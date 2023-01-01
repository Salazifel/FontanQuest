using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    public StoneKind StoneName;

    public enum StoneKind
    {
        Salt,
        Iron,
        Scandium,
        Aluminium,
        Rock,
        MagmaOre,
        IronOre
    }

    public string TextToStone()
    {
        switch (StoneName)
        {
            case StoneKind.Salt:
               return "Mhm that stone tastes like salt, I don't think that is what we are looking for";
            case StoneKind.Iron:
                return "Well thats already iron, but we are looking for iron ore";
            case StoneKind.Scandium:
                return "I don't think that's the right one";
            case StoneKind.Aluminium:
                return "Nope thats aluminium";
            case StoneKind.Rock:
                return "Just a normal rock";
            case StoneKind.MagmaOre:
                return "this one seems to be cold lava";
            case StoneKind.IronOre:
                return "Yeah, that must be the right one, unluckily its close the bear cub. ... Well ... let's just  grap it and run away. ";
            default:
                return "No thats not what we are looking for";
        }
    }
}
