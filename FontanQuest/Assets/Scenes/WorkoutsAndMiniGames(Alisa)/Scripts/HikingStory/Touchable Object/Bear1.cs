using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear1 : MonoBehaviour
{
    public kind Kind;

    public enum kind
    {
        Mother,
        Cup
    }
   public string TextToKind()
    {
        switch (Kind)
        {
            case kind.Mother:
                return "Die Baeren-Mutter sieht zwar aus als ob sie schlafen wuerde aber ihrem Jungen sollten wir trozdem nicht zu nahe kommen";
            case kind.Cup:
                return "Oh wie niedlich ist den diese Baeren Junge!!! Aber lass uns doch lieber wieder nach dem Eisenerz suchen";
            default:
                return "Das ist nicht das wonach wir suchen";
        }
    }
}
