using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentsMarket : MonoBehaviour
{
    // currency system 2DO
    // notification, dass die Kinder etwas gekauft haben 2DO

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
