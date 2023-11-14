public static class StaticResources
{
    private static int coins;

    public static int getNumOfCoins()
    {
        SaveGameObjects.GameData gameData = (SaveGameObjects.GameData)SaveGameMechanic.getSaveGameObjectByPrimaryKey(new SaveGameObjects.MainSaveObject(), "gameData", 1);
        coins = gameData.coins;
        return gameData.coins;
    }

    public static void addNumOfCoins(int change_value)
    {
        coins += change_value;
        SaveGameMechanic.saveSaveGameObject(new SaveGameObjects.GameData(coins), "gameData", 1);
    }

    public static int reduceNumOfCoins(int change_value)
    {
        if (coins - change_value < 0) {
            return 1;
        } else {
            coins -= change_value;
            SaveGameMechanic.saveSaveGameObject(new SaveGameObjects.GameData(coins), "gameData", 1);
            return 0;
        }
    }
}
