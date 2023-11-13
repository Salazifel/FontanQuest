public static class StaticResources
{
    private static int coins;
    public static int Coins
    {
        get
        {
            SaveGameObjects.GameData gameData = (SaveGameObjects.GameData)SaveGameMechanic.getSaveGameObjectByPrimaryKey(new SaveGameObjects.MainSaveObject(), "gameData", 1);
            return gameData.coins;
        }
        set
        {
            SaveGameMechanic.saveSaveGameObject(new SaveGameObjects.GameData(value), "gameData", 1);
            coins = value;
        }
    }

    public static void addNumOfCoins(int change_value)
    {
        Coins = coins + change_value;
    }

    public static int reduceNumOfCoins(int change_value)
    {
        if (coins - change_value < 0) {
            return 1;
        } else {
            Coins = coins - change_value;
            return 0;
        }
    }
}
