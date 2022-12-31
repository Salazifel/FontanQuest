using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ResourceContainer
{
    public static int Wood { get; private set; }
    public static int Stone { get; private set; }
    public static int Food { get; private set; }
    public static int Gold { get; private set; }
    public static void changeRes(int wood = 0, int stone = 0, int food = 0, int gold = 0)
    {
        Wood += wood;
        Stone += stone;
        Food += food;
        Gold += gold;
    }
}
