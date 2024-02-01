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
        SaveGameMechanic.saveSaveGameObject(RewardActivity1, "RewardGame");
        // DAY 2
        SaveGameObjects.DayActivity RewardActivity2 = new SaveGameObjects.DayActivity(DateTime.Today.AddDays(1));
        RewardActivity1.AddExercise(SceneManagerStaticScript.AvailableScenes.DoodleJumpRewardGame.ToString());
        SaveGameMechanic.saveSaveGameObject(RewardActivity2, "RewardGame");
        // DAY 3
        SaveGameObjects.DayActivity RewardActivity3 = new SaveGameObjects.DayActivity(DateTime.Today.AddDays(2));
        RewardActivity1.AddExercise(SceneManagerStaticScript.AvailableScenes.PetRewardGame.ToString());
        SaveGameMechanic.saveSaveGameObject(RewardActivity3, "RewardGame");
        // DAY 4
        SaveGameObjects.DayActivity RewardActivity4 = new SaveGameObjects.DayActivity(DateTime.Today.AddDays(3));
        SaveGameMechanic.saveSaveGameObject(RewardActivity4, "RewardGame");
        // DAY 5
        SaveGameObjects.DayActivity RewardActivity5 = new SaveGameObjects.DayActivity(DateTime.Today.AddDays(4));
        RewardActivity1.AddExercise(SceneManagerStaticScript.AvailableScenes.PetRewardGame.ToString());
        SaveGameMechanic.saveSaveGameObject(RewardActivity5, "RewardGame");
        // DAY 6
        SaveGameObjects.DayActivity RewardActivity6 = new SaveGameObjects.DayActivity(DateTime.Today.AddDays(5));
        RewardActivity1.AddExercise(SceneManagerStaticScript.AvailableScenes.DoodleJumpRewardGame.ToString());
        SaveGameMechanic.saveSaveGameObject(RewardActivity6, "RewardGame");
        // DAY 7
        SaveGameObjects.DayActivity RewardActivity7 = new SaveGameObjects.DayActivity(DateTime.Today.AddDays(6));
        RewardActivity1.AddExercise(SceneManagerStaticScript.AvailableScenes.PetRewardGame.ToString());
        SaveGameMechanic.saveSaveGameObject(RewardActivity7, "RewardGame");
        // DAY 8
        SaveGameObjects.DayActivity RewardActivity8 = new SaveGameObjects.DayActivity(DateTime.Today.AddDays(7));
        RewardActivity1.AddExercise(SceneManagerStaticScript.AvailableScenes.DoodleJumpRewardGame.ToString());
        SaveGameMechanic.saveSaveGameObject(RewardActivity8, "RewardGame");
        // DAY 9
        SaveGameObjects.DayActivity RewardActivity9 = new SaveGameObjects.DayActivity(DateTime.Today.AddDays(8));
        SaveGameMechanic.saveSaveGameObject(RewardActivity9, "RewardGame");
        // DAY 10
        SaveGameObjects.DayActivity RewardActivity10 = new SaveGameObjects.DayActivity(DateTime.Today.AddDays(9));
        RewardActivity1.AddExercise(SceneManagerStaticScript.AvailableScenes.PetRewardGame.ToString());
        SaveGameMechanic.saveSaveGameObject(RewardActivity10, "RewardGame");
        // DAY 11
        SaveGameObjects.DayActivity RewardActivity11 = new SaveGameObjects.DayActivity(DateTime.Today.AddDays(10));
        RewardActivity1.AddExercise(SceneManagerStaticScript.AvailableScenes.DoodleJumpRewardGame.ToString());
        SaveGameMechanic.saveSaveGameObject(RewardActivity11, "RewardGame");
        // DAY 12
        SaveGameObjects.DayActivity RewardActivity12 = new SaveGameObjects.DayActivity(DateTime.Today.AddDays(11));
        RewardActivity1.AddExercise(SceneManagerStaticScript.AvailableScenes.PetRewardGame.ToString());
        SaveGameMechanic.saveSaveGameObject(RewardActivity12, "RewardGame");
        // DAY 13
        SaveGameObjects.DayActivity RewardActivity13 = new SaveGameObjects.DayActivity(DateTime.Today.AddDays(12));
        RewardActivity1.AddExercise(SceneManagerStaticScript.AvailableScenes.DoodleJumpRewardGame.ToString());
        SaveGameMechanic.saveSaveGameObject(RewardActivity13, "RewardGame");
        // DAY 14
        SaveGameObjects.DayActivity RewardActivity14 = new SaveGameObjects.DayActivity(DateTime.Today.AddDays(13));
        RewardActivity1.AddExercise(SceneManagerStaticScript.AvailableScenes.PetRewardGame.ToString());
        SaveGameMechanic.saveSaveGameObject(RewardActivity14, "RewardGame");
    }
}
