using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class ActivityManagerPerDay
{
    public static void InitializeDailyActivities()
    {
        // Sportive Activities

        // Delete old file
        SaveGameMechanic.deleteBySaveFileName("DayActivity");

        // DAY 1
        SaveGameObjects.DayActivity dayActivity1 = new SaveGameObjects.DayActivity(DateTime.Today);
        dayActivity1.AddExercise(SceneManagerStaticScript.AvailableScenes.WoodCuttingExergame.ToString(), 5);
        dayActivity1.AddExercise(SceneManagerStaticScript.AvailableScenes.ObstacleRunning.ToString(), 5);
        SaveGameMechanic.saveSaveGameObject(dayActivity1, "DayActivity");
        // DAY 2
        SaveGameObjects.DayActivity dayActivity2 = new SaveGameObjects.DayActivity(DateTime.Today.AddDays(1));
        dayActivity2.AddExercise(SceneManagerStaticScript.AvailableScenes.AsianMonkExergame.ToString(), 5);
        dayActivity2.AddExercise(SceneManagerStaticScript.AvailableScenes.WoodCuttingExergame.ToString(), 5);
        SaveGameMechanic.saveSaveGameObject(dayActivity2, "DayActivity");
        // DAY 3
        SaveGameObjects.DayActivity dayActivity3 = new SaveGameObjects.DayActivity(DateTime.Today.AddDays(2));
        dayActivity3.AddExercise(SceneManagerStaticScript.AvailableScenes.HikingExergame.ToString(), 5);
        dayActivity3.AddExercise(SceneManagerStaticScript.AvailableScenes.MountainClimberExergame.ToString(), 5);
        SaveGameMechanic.saveSaveGameObject(dayActivity3, "DayActivity");
        // DAY 4
        SaveGameObjects.DayActivity dayActivity4 = new SaveGameObjects.DayActivity(DateTime.Today.AddDays(3));
        dayActivity4.AddExercise(SceneManagerStaticScript.AvailableScenes.WeedThePlant.ToString(), 5);
        dayActivity4.AddExercise(SceneManagerStaticScript.AvailableScenes.YouTubeScene.ToString(), 5);
        SaveGameMechanic.saveSaveGameObject(dayActivity4, "DayActivity");
        // DAY 5
        SaveGameObjects.DayActivity dayActivity5 = new SaveGameObjects.DayActivity(DateTime.Today.AddDays(4));
        dayActivity5.AddExercise(SceneManagerStaticScript.AvailableScenes.FitnessBoxing.ToString(), 5);
        dayActivity5.AddExercise(SceneManagerStaticScript.AvailableScenes.StoneCuttingExergame.ToString(), 5);
        SaveGameMechanic.saveSaveGameObject(dayActivity5, "DayActivity");
        // DAY 6
        SaveGameObjects.DayActivity dayActivity6 = new SaveGameObjects.DayActivity(DateTime.Today.AddDays(5));
        dayActivity6.AddExercise(SceneManagerStaticScript.AvailableScenes.AsianMonkExergame.ToString(), 5);
        dayActivity6.AddExercise(SceneManagerStaticScript.AvailableScenes.YouTubeScene.ToString(), 5);
        SaveGameMechanic.saveSaveGameObject(dayActivity6, "DayActivity");
        // DAY 7
        SaveGameObjects.DayActivity dayActivity7 = new SaveGameObjects.DayActivity(DateTime.Today.AddDays(6));
        dayActivity7.AddExercise(SceneManagerStaticScript.AvailableScenes.WoodCuttingExergame.ToString(), 5);
        dayActivity7.AddExercise(SceneManagerStaticScript.AvailableScenes.ObstacleRunning.ToString(), 5);
        SaveGameMechanic.saveSaveGameObject(dayActivity7, "DayActivity");
        // DAY 8
        SaveGameObjects.DayActivity dayActivity8 = new SaveGameObjects.DayActivity(DateTime.Today.AddDays(7));
        dayActivity8.AddExercise(SceneManagerStaticScript.AvailableScenes.FitnessBoxing.ToString(), 5);
        dayActivity8.AddExercise(SceneManagerStaticScript.AvailableScenes.YouTubeScene.ToString(), 5);
        SaveGameMechanic.saveSaveGameObject(dayActivity8, "DayActivity");
        // DAY 9
        SaveGameObjects.DayActivity dayActivity9 = new SaveGameObjects.DayActivity(DateTime.Today.AddDays(8));
        dayActivity9.AddExercise(SceneManagerStaticScript.AvailableScenes.AsianMonkExergame.ToString(), 5);
        dayActivity9.AddExercise(SceneManagerStaticScript.AvailableScenes.WoodCuttingExergame.ToString(), 5);
        SaveGameMechanic.saveSaveGameObject(dayActivity9, "DayActivity");
        // DAY 10
        SaveGameObjects.DayActivity dayActivity10 = new SaveGameObjects.DayActivity(DateTime.Today.AddDays(9));
        dayActivity10.AddExercise(SceneManagerStaticScript.AvailableScenes.StoneCuttingExergame.ToString(), 5);
        dayActivity10.AddExercise(SceneManagerStaticScript.AvailableScenes.YouTubeScene.ToString(), 5);
        SaveGameMechanic.saveSaveGameObject(dayActivity10, "DayActivity");
        // DAY 11
        SaveGameObjects.DayActivity dayActivity11 = new SaveGameObjects.DayActivity(DateTime.Today.AddDays(10));
        dayActivity11.AddExercise(SceneManagerStaticScript.AvailableScenes.HikingExergame.ToString(), 5);
        dayActivity11.AddExercise(SceneManagerStaticScript.AvailableScenes.WeedThePlant.ToString(), 5);
        SaveGameMechanic.saveSaveGameObject(dayActivity11, "DayActivity");
        // DAY 12
        SaveGameObjects.DayActivity dayActivity12 = new SaveGameObjects.DayActivity(DateTime.Today.AddDays(11));
        dayActivity12.AddExercise(SceneManagerStaticScript.AvailableScenes.FitnessBoxing.ToString(), 5);
        dayActivity12.AddExercise(SceneManagerStaticScript.AvailableScenes.YouTubeScene.ToString(), 5);
        SaveGameMechanic.saveSaveGameObject(dayActivity12, "DayActivity");
        // DAY 13
        SaveGameObjects.DayActivity dayActivity13 = new SaveGameObjects.DayActivity(DateTime.Today.AddDays(12));
        dayActivity13.AddExercise(SceneManagerStaticScript.AvailableScenes.StoneCuttingExergame.ToString(), 5);
        dayActivity13.AddExercise(SceneManagerStaticScript.AvailableScenes.ObstacleRunning.ToString(), 5);
        SaveGameMechanic.saveSaveGameObject(dayActivity13, "DayActivity");
        // DAY 14
        SaveGameObjects.DayActivity dayActivity14 = new SaveGameObjects.DayActivity(DateTime.Today.AddDays(13));
        dayActivity14.AddExercise(SceneManagerStaticScript.AvailableScenes.AsianMonkExergame.ToString(), 5);
        dayActivity14.AddExercise(SceneManagerStaticScript.AvailableScenes.YouTubeScene.ToString(), 5);
        SaveGameMechanic.saveSaveGameObject(dayActivity14, "DayActivity");


        // Reward Activities
        SaveGameMechanic.deleteBySaveFileName("RewardGame");

        // DAY 1
        SaveGameObjects.DayActivity RewardActivity1 = new SaveGameObjects.DayActivity(DateTime.Today);
        RewardActivity1.AddExercise(SceneManagerStaticScript.AvailableScenes.PetRewardGame.ToString());
        RewardActivity1.AddExercise(SceneManagerStaticScript.AvailableScenes.CastleScene.ToString());
        // DAY 2
        SaveGameObjects.DayActivity RewardActivity2 = new SaveGameObjects.DayActivity(DateTime.Today.AddDays(1));
        RewardActivity2.AddExercise(SceneManagerStaticScript.AvailableScenes.DoodleJumpRewardGame.ToString());
        RewardActivity2.AddExercise(SceneManagerStaticScript.AvailableScenes.CastleScene.ToString());
        // DAY 3
        SaveGameObjects.DayActivity RewardActivity3 = new SaveGameObjects.DayActivity(DateTime.Today.AddDays(2));
        RewardActivity3.AddExercise(SceneManagerStaticScript.AvailableScenes.PetRewardGame.ToString());
        RewardActivity3.AddExercise(SceneManagerStaticScript.AvailableScenes.CastleScene.ToString());
        // DAY 4
        SaveGameObjects.DayActivity RewardActivity4 = new SaveGameObjects.DayActivity(DateTime.Today.AddDays(3));
        RewardActivity4.AddExercise(SceneManagerStaticScript.AvailableScenes.PetRewardGame.ToString());
        RewardActivity4.AddExercise(SceneManagerStaticScript.AvailableScenes.CastleScene.ToString());
        // DAY 5
        SaveGameObjects.DayActivity RewardActivity5 = new SaveGameObjects.DayActivity(DateTime.Today.AddDays(4));
        RewardActivity5.AddExercise(SceneManagerStaticScript.AvailableScenes.PetRewardGame.ToString());
        RewardActivity5.AddExercise(SceneManagerStaticScript.AvailableScenes.CastleScene.ToString());
        // DAY 6
        SaveGameObjects.DayActivity RewardActivity6 = new SaveGameObjects.DayActivity(DateTime.Today.AddDays(5));
        RewardActivity6.AddExercise(SceneManagerStaticScript.AvailableScenes.DoodleJumpRewardGame.ToString());
        RewardActivity6.AddExercise(SceneManagerStaticScript.AvailableScenes.CastleScene.ToString());
        // DAY 7
        SaveGameObjects.DayActivity RewardActivity7 = new SaveGameObjects.DayActivity(DateTime.Today.AddDays(6));
        RewardActivity7.AddExercise(SceneManagerStaticScript.AvailableScenes.PetRewardGame.ToString());
        RewardActivity7.AddExercise(SceneManagerStaticScript.AvailableScenes.CastleScene.ToString());
        // DAY 8
        SaveGameObjects.DayActivity RewardActivity8 = new SaveGameObjects.DayActivity(DateTime.Today.AddDays(7));
        RewardActivity8.AddExercise(SceneManagerStaticScript.AvailableScenes.DoodleJumpRewardGame.ToString());
        RewardActivity8.AddExercise(SceneManagerStaticScript.AvailableScenes.CastleScene.ToString());
        // DAY 9
        SaveGameObjects.DayActivity RewardActivity9 = new SaveGameObjects.DayActivity(DateTime.Today.AddDays(8));
        RewardActivity9.AddExercise(SceneManagerStaticScript.AvailableScenes.CastleScene.ToString());
        // DAY 10
        SaveGameObjects.DayActivity RewardActivity10 = new SaveGameObjects.DayActivity(DateTime.Today.AddDays(9));
        RewardActivity10.AddExercise(SceneManagerStaticScript.AvailableScenes.PetRewardGame.ToString());
        RewardActivity10.AddExercise(SceneManagerStaticScript.AvailableScenes.CastleScene.ToString());
        // DAY 11
        SaveGameObjects.DayActivity RewardActivity11 = new SaveGameObjects.DayActivity(DateTime.Today.AddDays(10));
        RewardActivity11.AddExercise(SceneManagerStaticScript.AvailableScenes.DoodleJumpRewardGame.ToString());
        RewardActivity11.AddExercise(SceneManagerStaticScript.AvailableScenes.CastleScene.ToString());
        // DAY 12
        SaveGameObjects.DayActivity RewardActivity12 = new SaveGameObjects.DayActivity(DateTime.Today.AddDays(11));
        RewardActivity12.AddExercise(SceneManagerStaticScript.AvailableScenes.PetRewardGame.ToString());
        RewardActivity12.AddExercise(SceneManagerStaticScript.AvailableScenes.CastleScene.ToString());
        // DAY 13
        SaveGameObjects.DayActivity RewardActivity13 = new SaveGameObjects.DayActivity(DateTime.Today.AddDays(12));
        RewardActivity13.AddExercise(SceneManagerStaticScript.AvailableScenes.DoodleJumpRewardGame.ToString());
        RewardActivity13.AddExercise(SceneManagerStaticScript.AvailableScenes.CastleScene.ToString());
        // DAY 14
        SaveGameObjects.DayActivity RewardActivity14 = new SaveGameObjects.DayActivity(DateTime.Today.AddDays(13));
        RewardActivity14.AddExercise(SceneManagerStaticScript.AvailableScenes.PetRewardGame.ToString());
        RewardActivity14.AddExercise(SceneManagerStaticScript.AvailableScenes.CastleScene.ToString());

        // Parent's market
        SaveGameObjects.GameData gameData = (SaveGameObjects.GameData)SaveGameMechanic.getSaveGameObjectByPrimaryKey("GameData", 1);
        if (gameData == null)
        {
            gameData = (SaveGameObjects.GameData)SaveGameObjects.CreateSaveGameObject("GameData");
        }
        if (gameData.parentMarketActivated == true)
        {
            // DAY 1
            RewardActivity1.AddExercise(SceneManagerStaticScript.AvailableScenes.ParentsMarketKidsPerspective.ToString());
            // DAY 2
            RewardActivity2.AddExercise(SceneManagerStaticScript.AvailableScenes.ParentsMarketKidsPerspective.ToString());
            // DAY 3
            RewardActivity3.AddExercise(SceneManagerStaticScript.AvailableScenes.ParentsMarketKidsPerspective.ToString());
            // DAY 4
            RewardActivity4.AddExercise(SceneManagerStaticScript.AvailableScenes.ParentsMarketKidsPerspective.ToString());
            // DAY 5
            RewardActivity5.AddExercise(SceneManagerStaticScript.AvailableScenes.ParentsMarketKidsPerspective.ToString());
            // DAY 65
            RewardActivity6.AddExercise(SceneManagerStaticScript.AvailableScenes.ParentsMarketKidsPerspective.ToString());
            // DAY 7
            RewardActivity7.AddExercise(SceneManagerStaticScript.AvailableScenes.ParentsMarketKidsPerspective.ToString());
            // DAY 8
            RewardActivity8.AddExercise(SceneManagerStaticScript.AvailableScenes.ParentsMarketKidsPerspective.ToString());
            // DAY 9
            RewardActivity9.AddExercise(SceneManagerStaticScript.AvailableScenes.ParentsMarketKidsPerspective.ToString());
            // DAY 10
            RewardActivity10.AddExercise(SceneManagerStaticScript.AvailableScenes.ParentsMarketKidsPerspective.ToString());
            // DAY 11
            RewardActivity11.AddExercise(SceneManagerStaticScript.AvailableScenes.ParentsMarketKidsPerspective.ToString());
            // DAY 12
            RewardActivity12.AddExercise(SceneManagerStaticScript.AvailableScenes.ParentsMarketKidsPerspective.ToString());
            // DAY 13
            RewardActivity13.AddExercise(SceneManagerStaticScript.AvailableScenes.ParentsMarketKidsPerspective.ToString());
            // DAY 14
            RewardActivity14.AddExercise(SceneManagerStaticScript.AvailableScenes.ParentsMarketKidsPerspective.ToString());
        }

        // saving the Reward Games
        SaveGameMechanic.saveSaveGameObject(RewardActivity1, "RewardGame");
        SaveGameMechanic.saveSaveGameObject(RewardActivity2, "RewardGame");
        SaveGameMechanic.saveSaveGameObject(RewardActivity3, "RewardGame");
        SaveGameMechanic.saveSaveGameObject(RewardActivity4, "RewardGame");
        SaveGameMechanic.saveSaveGameObject(RewardActivity5, "RewardGame");
        SaveGameMechanic.saveSaveGameObject(RewardActivity6, "RewardGame");
        SaveGameMechanic.saveSaveGameObject(RewardActivity7, "RewardGame");
        SaveGameMechanic.saveSaveGameObject(RewardActivity8, "RewardGame");
        SaveGameMechanic.saveSaveGameObject(RewardActivity9, "RewardGame");
        SaveGameMechanic.saveSaveGameObject(RewardActivity10, "RewardGame");
        SaveGameMechanic.saveSaveGameObject(RewardActivity11, "RewardGame");
        SaveGameMechanic.saveSaveGameObject(RewardActivity12, "RewardGame");
        SaveGameMechanic.saveSaveGameObject(RewardActivity13, "RewardGame");
        SaveGameMechanic.saveSaveGameObject(RewardActivity14, "RewardGame");

        // Also initialize the daily health data 
        SaveGameMechanic.deleteBySaveFileName("SportLog");

        SaveGameMechanic.saveSaveGameObject(new SaveGameObjects.SportLog(DateTime.Today, 53, 49, 112), "SportLog");
        SaveGameMechanic.saveSaveGameObject(new SaveGameObjects.SportLog(DateTime.Today.AddDays(1), 53, 49, 112), "SportLog");
        SaveGameMechanic.saveSaveGameObject(new SaveGameObjects.SportLog(DateTime.Today.AddDays(2), 56, 44, 132), "SportLog");
        SaveGameMechanic.saveSaveGameObject(new SaveGameObjects.SportLog(DateTime.Today.AddDays(3), 58, 47, 131), "SportLog");
        SaveGameMechanic.saveSaveGameObject(new SaveGameObjects.SportLog(DateTime.Today.AddDays(4), 54, 48, 124), "SportLog");
        SaveGameMechanic.saveSaveGameObject(new SaveGameObjects.SportLog(DateTime.Today.AddDays(5), 55, 49, 127), "SportLog");
        SaveGameMechanic.saveSaveGameObject(new SaveGameObjects.SportLog(DateTime.Today.AddDays(6), 52, 50, 131), "SportLog");
        SaveGameMechanic.saveSaveGameObject(new SaveGameObjects.SportLog(DateTime.Today.AddDays(7), 59, 51, 134), "SportLog");
        SaveGameMechanic.saveSaveGameObject(new SaveGameObjects.SportLog(DateTime.Today.AddDays(8), 51, 45, 129), "SportLog");
        SaveGameMechanic.saveSaveGameObject(new SaveGameObjects.SportLog(DateTime.Today.AddDays(9), 53, 48, 135), "SportLog");
        SaveGameMechanic.saveSaveGameObject(new SaveGameObjects.SportLog(DateTime.Today.AddDays(10), 54, 43, 121), "SportLog");
        SaveGameMechanic.saveSaveGameObject(new SaveGameObjects.SportLog(DateTime.Today.AddDays(11), 56, 42, 126), "SportLog");
        SaveGameMechanic.saveSaveGameObject(new SaveGameObjects.SportLog(DateTime.Today.AddDays(12), 57, 47, 137), "SportLog");
        SaveGameMechanic.saveSaveGameObject(new SaveGameObjects.SportLog(DateTime.Today.AddDays(13), 54, 45, 118), "SportLog");
    }
}
