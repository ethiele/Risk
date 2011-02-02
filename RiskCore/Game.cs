using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RiskCore
{
    public class Game
    {
        public List<Territory> Territories { get; set; }
        public List<Continent> Continents { get; set; }
        public List<Player> Players { get; set; }

        public GameData GetGameData()
        {
            GameData gd = new GameData();
            gd.Territory.Rows.Add(GetTerritoryTable().Rows);
            gd.Continent.Rows.Add(GetContinentTable().Rows);
            gd.NextToLookup.Rows.Add(GetNextToLookupTable().Rows);
            gd.Player.Rows.Add(GetPlayerTable().Rows);
            return gd;
        }

        public void LoadGameData(GameData gd)
        {

            Continents.Clear();
            foreach (var item in gd.Continent)
            {
                Continents.Add(new Continent() { ID = item.ID, Name = item.Name, Value = item.Value });
            }
            
            Territories.Clear();
            foreach (var item in gd.Territory)
            {
                Territories.Add(new Territory() { ID = item.ID, Name = item.Name, UnitCount = item.UnitCount, PartOf = Continents.Where(p => p.ID == item.ID).Single() });
            }
            
        }

        GameData.TerritoryDataTable GetTerritoryTable()
        {
            GameData.TerritoryDataTable dt = new GameData.TerritoryDataTable();
            foreach (var item in Territories)
            {
                dt.AddTerritoryRow(item.ID, item.Name, item.PartOf.ID, item.ControlledBy.ID, item.UnitCount);
            }
            return dt;
        }

        GameData.ContinentDataTable GetContinentTable()
        {
            GameData.ContinentDataTable dt = new GameData.ContinentDataTable();
            foreach (var item in Continents)
            {
                dt.AddContinentRow(item.ID, item.Name, item.Value);
            }
            return dt;
        }

        GameData.NextToLookupDataTable GetNextToLookupTable()
        {
            GameData.NextToLookupDataTable dt = new GameData.NextToLookupDataTable();
            foreach (var item in Territories)
            {
                foreach (var terr2 in item.NextTo)
                {
                    dt.AddNextToLookupRow(item.ID, terr2.ID);
                }
            }
            return dt;
        }

        GameData.PlayerDataTable GetPlayerTable()
        {
            GameData.PlayerDataTable dt = new GameData.PlayerDataTable();
            foreach (var item in Players)
            {
                dt.AddPlayerRow(item.ID, item.Name);
            }
            return dt;
        }
        
    }
}
