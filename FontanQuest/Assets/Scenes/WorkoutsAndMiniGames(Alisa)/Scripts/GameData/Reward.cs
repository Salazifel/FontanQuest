using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reward 
{
   public enum kind
    {
        Wood,
        Food,
        Stone,
        Gold,
        EP,
        Villager
    }

    public kind Kind;
    public int Amount;

    public Reward(kind kind, int amount)
    {
        Kind = kind;
        Amount = amount;
    }
}
