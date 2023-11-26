using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AnimationLibrary
{
    public enum Animations
    {
        Walk,
        Talk
    }

    public static RuntimeAnimatorController getAnimationController(Animations animations)
    {
        string resourceName = "";
        if (animations == Animations.Talk) { resourceName = "BasicMotions@Talk_Resources"; }
        if (animations == Animations.Walk) { resourceName = "BasicMotions@Walk_Resources"; }
        return Resources.Load<RuntimeAnimatorController>("Animations/" + resourceName);
    }
}
