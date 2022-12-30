using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* ######## SCRIPT EXPLANATION ########
 * This script lists all available buil
 * dings in their specific Level. Furth
 * ermore it lists the required ressour
 * ces to build, boost and maintain the
 * m. Lastly, it contains functions to 
 * return those values to other scripts
 * 
 * ########       STATUS       ########
 *               ALL DONE
 *               
 * ########    LAST EDITED     ########
 *              19.12.2022
 */


public class Prices : MonoBehaviour
{
    // general class for all buildings
    public class Building
    {
        public int wood;
        public int stone;
        public int food;
        public int gold;
        public int foodBoost;
        public int goldUpkeep;
    }

        // HOUSING
            Building HouseLvl1;
            Building HouseLvl2;
            Building HouseLvl3;
        // TAVERN
            Building TavernLvl1;
            Building TavernLvl2;
            Building TavernLvl3;
        // WOODCUTTER
            Building WoodCutterLvl1;
            Building WoodCutterLvl2;
            Building WoodCutterLvl3;
        // STONEMINE
            Building StoneMineLvl1;
            Building StoneMineLvl2;
            Building StoneMineLvl3;
        // FARM
            Building FarmLvl1;
            Building FarmLvl2;
            Building FarmLvl3;
        // MAINBUILDING
            Building MainBuildingLvl1;
            Building MainBuildingLvl2;
            Building MainBuildingLvl3;
        // STABLES
            Building StablesLvl1;
            Building StablesLvl2;
            Building StablesLvl3;

    void Awake()
    {
        // Initializing the GameObjects

        // HOUSING
            Building HouseLvl1 = new Building();
            Building HouseLvl2 = new Building();
            Building HouseLvl3 = new Building();
        // TAVERN
            Building TavernLvl1 = new Building();
            Building TavernLvl2 = new Building();
            Building TavernLvl3 = new Building();
        // WOODCUTTER
            Building WoodCutterLvl1 = new Building();
            Building WoodCutterLvl2 = new Building();
            Building WoodCutterLvl3 = new Building();
        // STONEMINE
            Building StoneMineLvl1 = new Building();
            Building StoneMineLvl2 = new Building();
            Building StoneMineLvl3 = new Building();
        // FARM
            Building FarmLvl1 = new Building();
            Building FarmLvl2 = new Building();
            Building FarmLvl3 = new Building();
        // MAINBUILDING
            Building MainBuildingLvl1 = new Building();
            Building MainBuildingLvl2 = new Building();
            Building MainBuildingLvl3 = new Building();
        // STABLES
            Building StablesLvl1 = new Building();
            Building StablesLvl2 = new Building();
            Building StablesLvl3 = new Building();


        // Initializing the actual values for each building

        // HOUSING
            // define House Level 1
                HouseLvl1.wood = 10;
                HouseLvl1.stone = 10;
                HouseLvl1.food = 0;
                HouseLvl1.gold = 0;
                HouseLvl1.foodBoost = 10;
                HouseLvl1.goldUpkeep = 10;
            // define House Level 2
                HouseLvl2.wood = 50;
                HouseLvl2.stone = 50;
                HouseLvl2.food = 0;
                HouseLvl2.gold = 0;
                HouseLvl2.foodBoost = 20;
                HouseLvl2.goldUpkeep = 20;
            // define House Level 3
                HouseLvl3.wood = 100;
                HouseLvl3.stone = 100;
                HouseLvl3.food = 0;
                HouseLvl3.gold = 0;
                HouseLvl3.foodBoost = 30;
                HouseLvl3.goldUpkeep = 35;

        // TAVERN
            // define Tavern Level 1
                TavernLvl1.wood = 10;
                TavernLvl1.stone = 10;
                TavernLvl1.food = 0;
                TavernLvl1.gold = 0;
                TavernLvl1.foodBoost = 10;
                TavernLvl1.goldUpkeep = 10;
            // define Tavern Level 2
                TavernLvl2.wood = 50;
                TavernLvl2.stone = 50;
                TavernLvl2.food = 0;
                TavernLvl2.gold = 0;
                TavernLvl2.foodBoost = 20;
                TavernLvl2.goldUpkeep = 20;
            // define Tavern Level 3
                TavernLvl3.wood = 100;
                TavernLvl3.stone = 100;
                TavernLvl3.food = 0;
                TavernLvl3.gold = 0;
                TavernLvl3.foodBoost = 30;
                TavernLvl3.goldUpkeep = 35;

        // WOODCUTTER
            // define WoodCutter Level 1
                WoodCutterLvl1.wood = 10;
                WoodCutterLvl1.stone = 10;
                WoodCutterLvl1.food = 0;
                WoodCutterLvl1.gold = 0;
                WoodCutterLvl1.foodBoost = 10;
                WoodCutterLvl1.goldUpkeep = 10;
            // define WoodCutter Level 2
                WoodCutterLvl2.wood = 50;
                WoodCutterLvl2.stone = 50;
                WoodCutterLvl2.food = 0;
                WoodCutterLvl2.gold = 0;
                WoodCutterLvl2.foodBoost = 20;
                WoodCutterLvl2.goldUpkeep = 20;
            // define WoodCutter Level 3
                WoodCutterLvl3.wood = 100;
                WoodCutterLvl3.stone = 100;
                WoodCutterLvl3.food = 0;
                WoodCutterLvl3.gold = 0;
                WoodCutterLvl3.foodBoost = 30;
                WoodCutterLvl3.goldUpkeep = 35;

        // STONEMINE
            // define StoneMine Level 1
                StoneMineLvl1.wood = 10;
                StoneMineLvl1.stone = 10;
                StoneMineLvl1.food = 0;
                StoneMineLvl1.gold = 0;
                StoneMineLvl1.foodBoost = 10;
                StoneMineLvl1.goldUpkeep = 10;
            // define StoneMine Level 2
                StoneMineLvl2.wood = 50;
                StoneMineLvl2.stone = 50;
                StoneMineLvl2.food = 0;
                StoneMineLvl2.gold = 0;
                StoneMineLvl2.foodBoost = 20;
                StoneMineLvl2.goldUpkeep = 20;
            // define StoneMine Level 3
                StoneMineLvl3.wood = 100;
                StoneMineLvl3.stone = 100;
                StoneMineLvl3.food = 0;
                StoneMineLvl3.gold = 0;
                StoneMineLvl3.foodBoost = 30;
                StoneMineLvl3.goldUpkeep = 35;

        // FARM
            // define Farm Level 1
                FarmLvl1.wood = 10;
                FarmLvl1.stone = 10;
                FarmLvl1.food = 0;
                FarmLvl1.gold = 0;
                FarmLvl1.foodBoost = 10;
                FarmLvl1.goldUpkeep = 10;
            // define Farm Level 2
                FarmLvl2.wood = 50;
                FarmLvl2.stone = 50;
                FarmLvl2.food = 0;
                FarmLvl2.gold = 0;
                FarmLvl2.foodBoost = 20;
                FarmLvl2.goldUpkeep = 20;
            // define Farm Level 3
                FarmLvl3.wood = 100;
                FarmLvl3.stone = 100;
                FarmLvl3.food = 0;
                FarmLvl3.gold = 0;
                FarmLvl3.foodBoost = 30;
                FarmLvl3.goldUpkeep = 35;

        // MAINBUILDING
            // define MainBuilding Level 1
                MainBuildingLvl1.wood = 10;
                MainBuildingLvl1.stone = 10;
                MainBuildingLvl1.food = 0;
                MainBuildingLvl1.gold = 0;
                MainBuildingLvl1.foodBoost = 10;
                MainBuildingLvl1.goldUpkeep = 10;
            // define MainBuilding Level 2
                MainBuildingLvl2.wood = 50;
                MainBuildingLvl2.stone = 50;
                MainBuildingLvl2.food = 0;
                MainBuildingLvl2.gold = 0;
                MainBuildingLvl2.foodBoost = 20;
                MainBuildingLvl2.goldUpkeep = 20;
            // define MainBuilding Level 3
                MainBuildingLvl3.wood = 100;
                MainBuildingLvl3.stone = 100;
                MainBuildingLvl3.food = 0;
                MainBuildingLvl3.gold = 0;
                MainBuildingLvl3.foodBoost = 30;
                MainBuildingLvl3.goldUpkeep = 35;

        // STABLES
            // define Stables Level 1
                StablesLvl1.wood = 10;
                StablesLvl1.stone = 10;
                StablesLvl1.food = 0;
                StablesLvl1.gold = 0;
                StablesLvl1.foodBoost = 10;
                StablesLvl1.goldUpkeep = 10;
            // define Stables Level 2
                StablesLvl2.wood = 50;
                StablesLvl2.stone = 50;
                StablesLvl2.food = 0;
                StablesLvl2.gold = 0;
                StablesLvl2.foodBoost = 20;
                StablesLvl2.goldUpkeep = 20;
            // define Stables Level 3
                StablesLvl3.wood = 100;
                StablesLvl3.stone = 100;
                StablesLvl3.food = 0;
                StablesLvl3.gold = 0;
                StablesLvl3.foodBoost = 30;
                StablesLvl3.goldUpkeep = 35;
    }

    // functions to return the buildings into other scripts

        // HOUSING
            public Building ReturnHouseLvl1()
            {
                return HouseLvl1;
            }
            public Building ReturnHouseLvl2()
            {
                return HouseLvl2;
            }
            public Building ReturnHouseLvl3()
            {
                return HouseLvl3;
            }

        // TAVERN
            public Building ReturnTavernLvl1()
            {
                return TavernLvl1;
            }
            public Building ReturnTavernLvl2()
            {
                return TavernLvl2;
            }
            public Building ReturnTavernLvl3()
            {
                return TavernLvl3;
            }

        // WOODCUTTER
            public Building ReturnWoodCutterLvl1()
            {
                return WoodCutterLvl1;
            }
            public Building ReturnWoodCutterLvl2()
            {
                return WoodCutterLvl2;
            }
            public Building ReturnWoodCutterLvl3()
            {
                return WoodCutterLvl3;
            }

        // STONEMINE
            public Building ReturnStoneMinLvl1()
            {
                return StoneMineLvl1;
            }
            public Building ReturnStoneMinLvl2()
            {
                return StoneMineLvl2;
            }
            public Building ReturnStoneMinLvl3()
            {
                return StoneMineLvl3;
            }

        // FARM
            public Building ReturnFarmLvl1()
            {
                return FarmLvl1;
            }
            public Building ReturnFarmLvl2()
            {
                return FarmLvl2;
            }
            public Building ReturnFarmLvl3()
            {
                return FarmLvl3;
            }

        // MAINBUILDING
            public Building ReturnMainBuildingLvl1()
            {
                return MainBuildingLvl1;
            }
            public Building ReturnMainBuildingLvl2()
            {
                return MainBuildingLvl2;
            }
            public Building ReturnMainBuildingLvl3()
            {
                return MainBuildingLvl3;
            }
        // STABLES
            public Building ReturnStablesLvl1()
            {
                return StablesLvl1;
            }
            public Building ReturnStablesLvl2()
            {
                return StablesLvl2;
            }
            public Building ReturnStablesLvl3()
            {
                return StablesLvl3;
            }
}
