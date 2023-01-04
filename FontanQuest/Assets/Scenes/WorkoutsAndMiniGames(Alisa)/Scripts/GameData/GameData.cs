using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData 
{
    public static Game WoodChopping = new Game("WoodChopping", null, null);
    public static Game StoneMining = new Game("Stone Mining ", null, null);
    public static Game HikkingStory1 = new Game("Find the cure", new Reward(Reward.kind.Gold, 3), new Reward(Reward.kind.EP, 20));
}
