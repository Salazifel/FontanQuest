using System;
using UnityEngine;
using UnityEngine.UI;

public class ActivitySchedule : MonoBehaviour
{
    public Text activity1Text;
    public Text activity2Text;
    public Text dayProgressText;

    void Start()
    {
        // Load the GameData to get the first day of playing
        SaveGameObjects.GameData gameData = (SaveGameObjects.GameData)SaveGameMechanic.getSaveGameObjectByPrimaryKey("gameData", 1);
        if (gameData != null)
        {
            // If GameData is loaded successfully, use its firstDayOfPlaying to display activities
            DisplayActivitiesForDate(gameData.firstDayOfPlaying);
        }
        else
        {
            Debug.LogError("Failed to load GameData.");
        }
    }

    void DisplayActivitiesForDate(DateTime date)
    {
        // Correctly access the DayActivity for the specific date
        // The approach to identifying the specific DayActivity instance should align with your saving/loading mechanism

        // This example assumes you know how to access the DayActivity for 'date'
        // You need to replace the following line with the appropriate method to load the DayActivity for 'date'
        SaveGameObjects.DayActivity dayActivity = (SaveGameObjects.DayActivity)SaveGameMechanic.getSaveGameObjectByPrimaryKey("dayActivity", 1);

        if (dayActivity != null && dayActivity.exercises.Count > 0)
        {
            // Here, implement the logic to display the activities.
            // This might involve iterating over 'dayActivity.exercises' and updating UI elements accordingly.
            // For example:
            for (int i = 0; i < dayActivity.exercises.Count; i++)
            {
                var exercise = dayActivity.exercises[i];
                // Assuming you want to display the first two exercises in your UI
                if (i == 0)
                {
                    activity1Text.text = $"Exercise: {exercise.Item1}, Duration: {exercise.Item2} minutes";
                }
                else if (i == 1)
                {
                    activity2Text.text = $"Exercise: {exercise.Item1}, Duration: {exercise.Item2} minutes";
                    break; // Stop after setting the second exercise
                }
            }
        }
        else
        {
            // No activities found for this date
            activity1Text.text = "Kein Programm für diesen Tag";
            activity2Text.text = "";
            dayProgressText.text = "";
        }

        // Update day progress text, if applicable
        // This part of the logic remains unchanged
    }
}