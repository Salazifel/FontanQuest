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
        IronOre,
        Mountain
    }

    public string TextToStone()
    {
        switch (StoneName)
        {
            case StoneKind.Salt:
               return "Mhm dieser Stein schmeckt verdaechtig nach Salz";
            case StoneKind.Iron:
                return "Das ist richtiges Eisen, wir suchen nach Eisenerz";
            case StoneKind.Scandium:
                return "Ich glaube nicht das dass der richtige Stein ist";
            case StoneKind.Aluminium:
                return "Nope das ist Aluminium";
            case StoneKind.Rock:
                return "Nur ein normaler Stein";
            case StoneKind.MagmaOre:
                return "Das sieht aus wie abgekuehlte Lava";
            case StoneKind.IronOre:
                return "Oh ja das muss es sein! Aber es ist ziemlich nah an dem Baerenjungen. Lass es uns holen und dann machen wir uns so schnell wie möglich aus dem Staub";
            case StoneKind.Mountain:
                return "Dieser Berg sieht ziemlich merkwuerdig aus, wie der wohl entstanden ist?";
            default:
                return "Nein wir suchen nach einem komisch aussehenden Stein";
        }
    }
}
