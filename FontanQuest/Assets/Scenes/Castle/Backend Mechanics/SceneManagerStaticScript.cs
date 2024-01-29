using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SceneManagerStaticScript 
{
    public enum AvailableScenes
    {
        CastleScene,
        DoodleJumpRewardGame,
        HikingExergame,
        StoneCuttingExergame,
        WoodCuttingExergame,
        PetRewardGame,
        MountainClimberExergame,


        YouTubeScene,
        ParentsMarketKidsPerspective,
        ParentsMarketParentsPerspective,
        ParentsScreen
    }

    public static Dictionary<AvailableScenes, string> sceneDictionary = new Dictionary<AvailableScenes, string>
    {
        {AvailableScenes.CastleScene, "Main_Castle"}
    };

    public static string GetSceneName(AvailableScenes availableScenes)
    {
        // Check if the key exists in the dictionary
        if (sceneDictionary.TryGetValue(availableScenes, out string sceneName))
        {
            return sceneName;
        }
        else
        {
            return "Main_Castle"; // Or any default value you prefer
        }
    }
}
