using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentsMarket : MonoBehaviour
{
    // ------------------------------ Currency Elements

    public bool changeNumOfCoins(int changeVal)
    {
        SaveGameObjects.GameData gameData = (SaveGameObjects.GameData)SaveGameMechanic.getSaveGameObjectByPrimaryKey("GameData", 1);
        if (gameData == null)
        {
            gameData = (SaveGameObjects.GameData)SaveGameObjects.CreateSaveGameObject("GameData");
        }
        
        if ((gameData.coins + changeVal) < 0)
        {
            return false;
        } 
        else 
        {
            gameData.coins = gameData.coins + changeVal;
            SaveGameMechanic.saveSaveGameObject(gameData, "GameData", 1);
            return true;
        }
    }

    public int getNumOfCoins()
    {
        SaveGameObjects.GameData gameData = (SaveGameObjects.GameData)SaveGameMechanic.getSaveGameObjectByPrimaryKey("GameData", 1);
        if (gameData == null)
        {
            gameData = (SaveGameObjects.GameData)SaveGameObjects.CreateSaveGameObject("GameData");
        }
        return gameData.coins;
    }


    // ------------------------------ MARKET ELEMENTS 

    private int numOfDefaultOffers = 1;
    public void addMarketOffer(SaveGameObjects.MarketOffer marketOffer)
    {
        List<SaveGameObjects.MarketOffer> marketOffers = loadMarketOffers();
        marketOffers.Add(marketOffer);
        saveMarketOffers(marketOffers);
    }   

    public List<SaveGameObjects.MarketOffer> loadMarketOffers() 
    {
        List<SaveGameObjects.MainSaveObject> marketOffers = SaveGameMechanic.getAllSaveGameObjectsOfType("MarketOffer", "MarketOffer");
        if (marketOffers.Count < numOfDefaultOffers)
        {
            return createDefaultMarketOfferList();
        }
        
        List<SaveGameObjects.MarketOffer> newMarketOffers = new List<SaveGameObjects.MarketOffer>();
        for (int i = 0; i < marketOffers.Count; i++)
        {
            newMarketOffers.Add((SaveGameObjects.MarketOffer) marketOffers[i]);
        }
        return newMarketOffers;
    }

    public void saveMarketOffers(List<SaveGameObjects.MarketOffer> marketOffers)
    {
        SaveGameMechanic.deleteGameSaveType(new SaveGameObjects.MarketOffer(null, null, 0, 0), "MarketOffer");
        for (int i = 0; i < marketOffers.Count; i++)
        {
            SaveGameMechanic.saveSaveGameObject(marketOffers[i], "MarketOffers");            
        }
    }

    private List<SaveGameObjects.MarketOffer> createDefaultMarketOfferList()
    {
        List<SaveGameObjects.MarketOffer> marketOffers = new List<SaveGameObjects.MarketOffer>();

        // change num of Default offers
        marketOffers.Add(new SaveGameObjects.MarketOffer("PC spielen", "ParentsmarketIcons/PC", 5, 0));
    

        return marketOffers;
    }
}
