using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ResourceContainer
{
    // current ressources
    public static int Wood { get; private set; }
    public static int Stone { get; private set; }
    public static int Food { get; private set; }
    public static int Gold { get; private set; }

    // maximum ressources
    public static int MaxWood { get; private set; }
    public static int MaxStone { get; private set; }
    public static int MaxFood { get; private set; }
    
    public static void changeRes(int wood = 0, int stone = 0, int food = 0, int gold = 0)
    {
        Wood += wood;
        Stone += stone;
        Food += food;
        Gold += gold;
    }

    public static void TestResources()
    {
        Wood = 120; // above limit for testing
        Stone = 100;
        Food = 100;
        Gold = 10;
    }

    public static bool CheckRessources(int woodc, int stonec, int foodc, int goldc)
    {
        bool affordable = true;

        if (woodc > Wood)
            { affordable = false; }
        if (stonec > Stone)
            { affordable = false; }
        if (foodc > Food)
            { affordable = false; }
        if (goldc > Gold)
            { affordable = false; }

        return affordable;
    }

    public static void setMaxRes(int maxWood = 100, int maxStone = 100, int maxFood = 100)
    {
        MaxWood += maxWood;
        MaxStone += maxStone;
        MaxFood += maxFood;
    }

    public static int[] getMaxRes()
    {
        int[] maxRes = new int[3];

        maxRes[0] = MaxWood;
        maxRes[1] = MaxStone;
        maxRes[2] = MaxFood;

        return maxRes;
    }

    public static void setRes(int wood = 0, int stone = 0, int food = 0, int gold = 0)
    {
        Wood = wood;
        Stone = stone;
        Food = food;
        Gold = gold;
    }

    public static int[] getRes()
    {
        int[] res = new int[4];

        res[0] = Wood;
        res[1] = Stone;
        res[2] = Food;
        res[3] = Gold;

        return res;
    }
}
