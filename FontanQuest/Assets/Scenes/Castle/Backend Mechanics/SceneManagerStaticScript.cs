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
        ObstacleRunning,
        AsianMonkExergame,
        FitnessBoxing,
        WeedThePlant,


        YouTubeScene,
        ParentsMarketKidsPerspective,
        ParentsMarketParentsPerspective,
        ParentsScreen
    }

    public static Dictionary<AvailableScenes, string> sceneDictionary = new Dictionary<AvailableScenes, string>
    {
        {AvailableScenes.CastleScene, "Main_Castle"},
        {AvailableScenes.DoodleJumpRewardGame, "DoodleJumpStoryScene"},
        {AvailableScenes.HikingExergame, "HikkingStoryManager"},
        {AvailableScenes.StoneCuttingExergame, "StoneCrushing"},
        {AvailableScenes.WoodCuttingExergame, "WoodChopping"},
        {AvailableScenes.PetRewardGame, "Pet"},
        {AvailableScenes.MountainClimberExergame, "TreeClimber"},
        {AvailableScenes.ObstacleRunning, "ObstacleRunning_0"},
        {AvailableScenes.AsianMonkExergame, "AM-2D-Game"},
        {AvailableScenes.FitnessBoxing, "FitnessBoxing"},
        {AvailableScenes.WeedThePlant, "WeedThePlant"},

        {AvailableScenes.YouTubeScene, "VideoSelection"},
        {AvailableScenes.ParentsMarketKidsPerspective, "ParentsMarketForChildren"},
        {AvailableScenes.ParentsMarketParentsPerspective, ""},
        {AvailableScenes.ParentsScreen, "HomeParentSection"}
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
